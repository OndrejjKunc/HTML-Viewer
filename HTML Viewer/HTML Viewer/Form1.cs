using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_Viewer
{
    public partial class Form1 : Form
    {
        Node root;
        private void AddToTreeView(Node node, TreeNode parent = null)
        {
            if(node is Element)
            {
                Element e = (Element)node;
                TreeNode newParent;
                if (parent != null)
                {
                    parent.Nodes.Add($"Element: \"{e.TagName}\"");
                    newParent = parent.Nodes[parent.Nodes.Count - 1];
                }
                else
                {
                    TreeViewer.Nodes.Add($"Element: \"{e.TagName}\"");
                    newParent = TreeViewer.Nodes[0];
                }
                foreach (Attribute attribute in e.Attributes)
                {
                    newParent.Nodes.Add($"Attribute: \"{attribute.Name}\"");
                    newParent.Nodes[0].Nodes.Add($"Value: \"{attribute.Value}\"");
                }
                foreach (Node child in e.Children)
                {
                    AddToTreeView(child, newParent);
                }
            }
            else //node je Text
            {
                Text t = (Text)node;
                parent.Nodes.Add($"Text: \"{t.Value}\"");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "html files (*.html)|*.html";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputPath = openFileDialog.FileName;
                string input = File.ReadAllText(inputPath);
                Parser parser = new Parser(input);
                root = parser.Parse();

                AddToTreeView(root);
                TreeViewer.ExpandAll();
            }
        }
    }

    public class Attribute
    {
        public string Name;
        public string Value;

        public Attribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public class Element : Node
    {
        public string TagName;
        public List<Attribute> Attributes = new List<Attribute>();
        public List<Node> Children = new List<Node>();

        public Element(string tagName, List<Attribute> attributes, List<Node> children)
        {
            TagName = tagName;
            Attributes = attributes;
            Children = children;
        }
    }

    public class Text : Node
    {
        public string Value;
        public Text(string t)
        {
            Value = t;
        }
    }

    public class Node
    {

    }

    public class Parser
    {
        int pos = 0; //Ukazatel soucasne pozice vstupu.
        string input; //Text HTML vstupu.
        List<string> selfClosingTags = new List<string>() { "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "param", "source", "track", "wbr" };

        private bool Eof()
        {
            return (pos >= input.Length);
        }

        private char ReadChar(bool advance) //Precte nasledujici znak inputu s moznosti posunout ukazatel pozice.
        {
            char c = input[pos];
            if (advance)
            {
                pos++;
            }
            return c;
        }

        private string ReadWhile(Func<Boolean> condition) //Cte znaky dokud plati condition, vysledek vrati ve stringu.
        {
            string s = "";
            while(condition())
            {
                s += ReadChar(true);
            }
            return s;
        }

        private void ConsumeWhitespace() //Posune ukazatel dokud nasledujici znak neni whitespace.
        {
            if (pos < input.Length)
            {
                ReadWhile(() => Char.IsWhiteSpace(ReadChar(false)));
            }
        }

        private string ReadName()
        {
            return ReadWhile(() => ( Char.IsLetterOrDigit(ReadChar(false))) );
        } //Precte alfanumericky nazev tagu nebo attributu.

        private string ReadAttributeValue()
        {
            ReadChar(true); // "
            string value = ReadWhile(() => ReadChar(false) != '"');
            ReadChar(true); // "
            return value;
        } //Precte hodnotu ohranicenou uvozovkami.

        private Attribute ParseAttribute()
        {
            string name = ReadName();
            ReadChar(true); // =
            string value = ReadAttributeValue();
            return new Attribute(name, value);
        }

        private List<Attribute> ParseAttributes()
        {
            List<Attribute> attributes = new List<Attribute>();
            while(true)
            {
                ConsumeWhitespace();
                if (ReadChar(false) == '>')
                {
                    break;
                }
                Attribute attribute = ParseAttribute();
                attributes.Add(attribute);
            }
            return attributes;
        }
        
        private bool isSelfClosing(string name)
        {
            return selfClosingTags.Contains(name);
        }

        private Element ParseElement() //Precte a vrati element.
        {
            string tagName;
            List<Attribute> attributes = new List<Attribute>();
            List<Node> children = new List<Node>();

            ReadChar(true); //<
            tagName = ReadName();
            attributes = ParseAttributes();
            ReadChar(true); //>

            if (!isSelfClosing(tagName))
            {
                children = ParseNodes();

                ReadChar(true); // <
                ReadChar(true); // /
                ReadName();
                ReadChar(true); // >
            }

            Element e = new Element(tagName, attributes, children);
            return e;
        }

        private Text ParseText() //Precte a vrati text do zacatku nasledujiciho elementu.
        {
            Text t = new Text( ReadWhile(() => ReadChar(false) != '<') );
            return t;
        }

        private List<Node> ParseNodes()
        {
            List<Node> nodes = new List<Node>();
            while(true)
            {
                ConsumeWhitespace();
                if (Eof() || input.Substring(pos, 2) == "</")
                {
                    break;
                }
                nodes.Add(ParseNode());
            }
            return nodes;
        }

        private Node ParseNode()
        {
            Node n = new Node();
            if (ReadChar(false) == '<') //Element
            {
                n = ParseElement();
            }
            else //Text
            {
                n = ParseText();
            }
            return n;
        }

        public Node Parse() //Precte input a vrati root node, popr. prida root node pokud uz neexisture.
        {
            if (input.StartsWith("<!DOCTYPE html>"))
            {
                input = input.Remove(0, 15);
                ConsumeWhitespace();
            }

            List<Node> nodes = ParseNodes();

            Node node;
            if (nodes.Count == 1)
            {
                node = nodes[0];
            }
            else
            {
                node = new Element("html", new List<Attribute>(), nodes);
            }

            return node;
        }

        public Parser(string _input)
        {
            input = _input;
        }

    }
}
