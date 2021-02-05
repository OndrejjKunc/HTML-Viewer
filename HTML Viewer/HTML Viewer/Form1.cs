using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_Viewer
{
    public partial class Form1 : Form
    {
        Node root;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        Parser parser = new Parser();
        Serializer serializer = new Serializer();

        public Form1()
        {
            InitializeComponent();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "html files (*.html)|*.html";

            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "html file (*.html)|*.html";
        }

        private void AddToTreeView(Node node, TreeNode parent = null)
        {
            TreeNode newNode;
            if(node is Element)
            {
                Element e = (Element)node;
                if (parent != null)
                {
                    parent.Nodes.Add($"<{e.TagName}>");
                    newNode = parent.Nodes[parent.Nodes.Count - 1];
                    newNode.ImageIndex = 0;
                    newNode.SelectedImageIndex = 0;
                }
                else
                {
                    TreeViewer.Nodes.Add($"<{e.TagName}>");
                    newNode = TreeViewer.Nodes[0];
                    newNode.ImageIndex = 0;
                    newNode.SelectedImageIndex = 0;
                }
                newNode.Tag = e;
                foreach (Attribute attribute in e.Attributes)
                {
                    newNode.Nodes.Add($"{attribute.Name}=");
                    newNode.Nodes[newNode.Nodes.Count - 1].Tag = attribute;
                    newNode.Nodes[newNode.Nodes.Count - 1].Nodes.Add($"\"{attribute.Value}\"");
                    newNode.Nodes[newNode.Nodes.Count - 1].Nodes[0].Tag = attribute;
                    newNode.Nodes[newNode.Nodes.Count - 1].ImageIndex = 1;
                    newNode.Nodes[newNode.Nodes.Count - 1].SelectedImageIndex = 1;
                    newNode.Nodes[newNode.Nodes.Count - 1].Nodes[0].ImageIndex = 2;
                    newNode.Nodes[newNode.Nodes.Count - 1].Nodes[0].SelectedImageIndex = 2;
                }
                foreach (Node child in e.Children)
                {
                    AddToTreeView(child, newNode);
                }
            }
            else //node je Text
            {
                Text t = (Text)node;
                parent.Nodes.Add(t.Value);
                newNode = parent.Nodes[parent.Nodes.Count - 1];
                newNode.Tag = t;
                newNode.ImageIndex = 3;
                newNode.SelectedImageIndex = 3;
            }
        }

        private void UpdateTree()
        {
            TreeViewer.Nodes.Clear();
            AddToTreeView(root);
            TreeViewer.ExpandAll();
        }

        private void openFile(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputPath = openFileDialog.FileName;
                string inputText = File.ReadAllText(inputPath);
                
                root = parser.Parse(inputText);

                UpdateTree();
            }
        }

        private void editValue(object sender, EventArgs e)
        {
            var n = TreeViewer.SelectedNode.Tag;
            if (n is Element)
            {
                Element element = (Element)n;
                element.TagName = editBox.Text;
                TreeViewer.SelectedNode.Text = $"<{editBox.Text}>";
            }
            else if (n is Text)
            {
                Text text = (Text)n;
                text.Value = editBox.Text;
                TreeViewer.SelectedNode.Text = editBox.Text;
            }
            else
            {
                Attribute a = (Attribute)n;
                if (TreeViewer.SelectedNode.Text[0] == '"')
                {
                    a.Value = editBox.Text;
                    TreeViewer.SelectedNode.Text = $"\"{editBox.Text}\"";
                }
                else
                {
                    a.Name = editBox.Text;
                    TreeViewer.SelectedNode.Text = $"{editBox.Text}=";
                }
            }
        }

        private void updateTextBox(object sender, TreeViewEventArgs e)
        {
            var n = TreeViewer.SelectedNode.Tag;
            if (n is Element)
            {
                Element element = (Element)n;
                editBox.Text = element.TagName;
            }
            else if (n is Text)
            {
                Text text = (Text)n;
                editBox.Text = text.Value;
            }
            else
            {
                Attribute a = (Attribute)n;
                if (TreeViewer.SelectedNode.Text[0] == '"')
                {
                    editBox.Text = a.Value;
                }
                else
                {
                    editBox.Text = a.Name;
                }
            }
        }

        private void saveFile(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, serializer.Serialize(root));
            }
        }

        private void downloadFile(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                root = parser.Parse(webClient.DownloadString(urlBox.Text));
                UpdateTree();
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

    public class Serializer
    {
        private Node root;
        private string output;
        private int indent = 0;
        List<string> selfClosingTags = new List<string>() { "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "param", "source", "track", "wbr" };

        private bool isSelfClosing(string name)
        {
            return selfClosingTags.Contains(name);
        }

        private void AddToOutput(Node node) //htmlText
        {
            if (node is Element)
            {
                output += Environment.NewLine;
                output += new String('\t', indent);
                Element e = (Element)node;

                //Otvirajici tag + attributy
                output += $"<{e.TagName}";
                foreach(Attribute attribute in e.Attributes)
                {
                    output += $" {attribute.Name}=\"{attribute.Value}\"";
                }
                output += ">";


                if (!isSelfClosing(e.TagName))
                {
                    //Vyjimka: pokud ma element pouze jedno dite a to Test (<b>Priklad</b>), pro citelnost vystupu napiseme cely element na jeden radek
                    if (e.Children.Count == 1 && e.Children[0] is Text)
                    {
                        Text t = (Text)e.Children[0];
                        output += t.Value;
                        output += $"</{e.TagName}>";
                    }
                    else
                    {
                        //Deti
                        indent++;
                        foreach (Node child in e.Children)
                        {
                            AddToOutput(child);
                        }
                        indent--;

                        //Uzavirajici tag
                        output += Environment.NewLine;
                        output += new String('\t', indent);
                        output += $"</{e.TagName}>";
                    }
                }
            }
            else if (node is Text)
            {
                Text t = (Text)node;
                output += t.Value;
            }
        }

        public string Serialize()
        {
            output = "<!DOCTYPE html>";
            AddToOutput(root);
            return output;
        }

        public string Serialize(Node node)
        {
            root = node;
            return Serialize();
        }

        public Serializer()
        {
            root = null;
        }

        public Serializer(Node node)
        {
            root = node;
        }
    }

    public class Parser
    {
        private int pos = 0; //Ukazatel soucasne pozice vstupu.
        public string input; //Text HTML vstupu.
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
            while(pos < input.Length && condition())
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
            if (input.StartsWith("<!DOCTYPE html>", true, null))
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

        public Node Parse(string _input)
        {
            input = _input;
            return Parse();
        }

        public Parser()
        {
            input = "";
        }

        public Parser(string _input)
        {
            input = _input;
        }

    }
}
