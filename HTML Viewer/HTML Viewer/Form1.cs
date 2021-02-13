using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;

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
            editBox.AutoSize = false;
            urlBox.AutoSize = false;

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "html files (*.html)|*.html";

            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "html file (*.html)|*.html";

            InitializeDefault();
        }

        private void InitializeDefault()
        {
            Element node = new Element("html");
            List<Node> children = new List<Node>();
            children.Add(new Element("head"));
            children.Add(new Element("body"));
            node.Children = children;

            root = (Node)node;

            UpdateTree();
        }

        private TreeNode AddToTreeView(Node node, TreeNode parent = null)
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
            else if (node is Text)
            {
                Text t = (Text)node;
                parent.Nodes.Add(t.Value);
                newNode = parent.Nodes[parent.Nodes.Count - 1];
                newNode.Tag = t;
                newNode.ImageIndex = 3;
                newNode.SelectedImageIndex = 3;
            }
            else //node je Comment.
            {
                Comment c = (Comment)node;
                parent.Nodes.Add($"<!--{c.Value}-->");
                newNode = parent.Nodes[parent.Nodes.Count - 1];
                newNode.Tag = c;
                newNode.ImageIndex = 4;
                newNode.SelectedImageIndex = 4;
            }

            return newNode;
        }

        private void UpdateTree()
        {
            TreeViewer.Nodes.Clear();
            AddToTreeView(root);
            TreeViewer.ExpandAll();
            TreeViewer.Select();
            TreeViewer.SelectedNode = TreeViewer.Nodes[0];
        }

        private void UpdateSelect(object sender, TreeViewEventArgs e) //Po zmene vybrane node v TreeViewer aktualizuje povolene akce a text v editBoxu.
        {
            var treeNode = TreeViewer.SelectedNode;
            var tag = treeNode.Tag;
            if (tag is Element)
            {
                Element element = (Element)tag;
                editBox.Text = element.TagName;
            }
            else if (tag is Text)
            {
                Text text = (Text)tag;
                editBox.Text = text.Value;
            }
            else if (tag is Attribute)
            {
                Attribute attribute = (Attribute)tag;
                if (IsValueOfAttribute(treeNode))
                {
                    editBox.Text = attribute.Value;
                }
                else
                {
                    editBox.Text = attribute.Name;
                }
            }
            else //tag je Comment
            {
                Comment comment = (Comment)tag;
                editBox.Text = comment.Value;
            }

            UpdateButtons();
        }

        private void UpdateButtons() //Aktualizuje povolena tlacitka.
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            var tag = treeNode.Tag;

            if (tag == root) //root nemuzeme posouvat ani mazat.
            {
                deleteButton.Enabled = false;
                upButton.Enabled = false;
                downButton.Enabled = false;
            }
            else
            {
                TreeNode parent = treeNode.Parent;
                int index = treeNode.Parent.Nodes.IndexOf(treeNode);

                upButton.Enabled = !(tag == treeNode.Parent.Nodes[0].Tag); //Prvni dite node nemuzeme posouvat nahoru.
                downButton.Enabled = !(tag == treeNode.Parent.Nodes[treeNode.Parent.Nodes.Count - 1].Tag); //Posledni dite node nemuzeme posouvat dolu.
                if (tag is Attribute) //Zabrani michani attributu a elementu
                {
                    if (parent.Nodes.Count > index + 1)
                    {
                        downButton.Enabled = (parent.Nodes[index + 1].Tag is Attribute);
                    }
                }
                else
                {
                    if (index > 0)
                    {
                        upButton.Enabled = !(parent.Nodes[index - 1].Tag is Attribute);
                    }
                }
                deleteButton.Enabled = true;
            }

            if (tag is Element)
            {
                addElementButton.Enabled = true;
                addAttributeButton.Enabled = true;
                addTextButton.Enabled = true;
                addCommentButton.Enabled = true;
            }
            else
            {
                addElementButton.Enabled = false;
                addAttributeButton.Enabled = false;
                addTextButton.Enabled = false;
                addCommentButton.Enabled = false;
            }
        }

        private void NewFile(object sender, EventArgs e)
        {
            InitializeDefault();
        }

        private void SaveFile(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, serializer.Serialize(root));
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputPath = openFileDialog.FileName;
                string inputText = File.ReadAllText(inputPath);

                root = parser.Parse(inputText);

                UpdateTree();
            }
        }

        private void DownloadFile(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                root = parser.Parse(webClient.DownloadString(urlBox.Text));
                UpdateTree();
            }
        }

        private bool IsValueOfAttribute(TreeNode treeNode)
        {
            return (treeNode.Text[0] == '"');
        }

        private void EditValue()
        {
            var tag = TreeViewer.SelectedNode.Tag;
            if (tag is Element)
            {
                Element element = (Element)tag;
                element.TagName = editBox.Text;
                TreeViewer.SelectedNode.Text = $"<{editBox.Text}>";
            }
            else if (tag is Text)
            {
                Text text = (Text)tag;
                text.Value = editBox.Text;
                TreeViewer.SelectedNode.Text = editBox.Text;
            }
            else if (tag is Attribute)
            {
                Attribute attribute = (Attribute)tag;
                if (IsValueOfAttribute(TreeViewer.SelectedNode))
                {
                    attribute.Value = editBox.Text;
                    TreeViewer.SelectedNode.Text = $"\"{editBox.Text}\"";
                }
                else
                {
                    attribute.Name = editBox.Text;
                    TreeViewer.SelectedNode.Text = $"{editBox.Text}=";
                }
            }
            else //node je Comment
            {
                Comment comment = (Comment)tag;
                comment.Value = editBox.Text;
                TreeViewer.SelectedNode.Text = $"<!--{editBox.Text}-->";
            }
        }

        private void EditValue(object sender, EventArgs e)
        {
            EditValue();
        }

        private void TreeSwap(TreeNodeCollection nodes, int indexA, int indexB)
        {
            if (indexA > indexB)
            {
                indexA = indexA + indexB;
                indexB = indexA - indexB;
                indexA = indexA - indexB;
            }
            TreeNode tempA = nodes[indexA];
            TreeNode tempB = nodes[indexB];
            nodes.RemoveAt(indexB);
            nodes.RemoveAt(indexA);
            nodes.Insert(indexA, tempB);
            nodes.Insert(indexB, tempA);
        }

        private void ListSwap<T>(List<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        private void MoveNode(int distance)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            TreeNode parent = treeNode.Parent;
            int index = parent.Nodes.IndexOf(treeNode);
            TreeSwap(parent.Nodes, index, index + distance);

            var tag = treeNode.Tag;
            Element element = (Element)parent.Tag;
            if (tag is Attribute)
            {
                Attribute attribute = (Attribute)treeNode.Tag;
                index = element.Attributes.IndexOf(attribute);
                ListSwap<Attribute>(element.Attributes, index, index + distance);
            }
            else
            {
                Node node = (Node)treeNode.Tag;
                index = element.Children.IndexOf(node);
                ListSwap<Node>(element.Children, index, index + distance);
            }

            TreeViewer.SelectedNode = treeNode;
        }

        private void MoveUp(object sender, EventArgs e)
        {
            MoveNode(-1);
        }

        private void MoveDown(object sender, EventArgs e)
        {
            MoveNode(1);
        }

        private void DeleteNode(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            var tag = treeNode.Tag;
            
            if (tag is Attribute) //Pokud je atribut, odstranime z seznamu atributu rodice.
            {
                Attribute attribute = (Attribute)tag;
                if (IsValueOfAttribute(treeNode))
                {
                    treeNode = treeNode.Parent;
                }
                Element parent = (Element)treeNode.Parent.Tag;
                parent.Attributes.Remove(attribute);
            }
            else //Odstranime z seznamu deti rodice.
            {
                Element parent = (Element)treeNode.Parent.Tag;
                Node node = (Node)tag;
                parent.Children.Remove(node);
            }
            treeNode.Remove();
        }

        private void AddElement(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            Element parent = (Element)treeNode.Tag;
            Element element = new Element("div");
            parent.Children.Add(element);

            treeNode.Expand();
            TreeViewer.SelectedNode = AddToTreeView(element, treeNode);
            TreeViewer.Select();
        }

        private void AddAttribute(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            Element parent = (Element)treeNode.Tag;
            Attribute attribute = new Attribute("class", "value");
            parent.Attributes.Add(attribute);

            int index = 0;
            foreach(TreeNode child in treeNode.Nodes)
            {
                if (child.ImageIndex != 1)
                {
                    break;
                }
                index++;
            }

            treeNode.Nodes.Insert(index, $"{attribute.Name}=");
            treeNode.Nodes[index].Tag = attribute;
            treeNode.Nodes[index].ImageIndex = 1;
            treeNode.Nodes[index].SelectedImageIndex = 1;
            treeNode.Nodes[index].Nodes.Add($"\"{attribute.Value}\"");
            treeNode.Nodes[index].Nodes[0].Tag = attribute;
            treeNode.Nodes[index].Nodes[0].ImageIndex = 2;
            treeNode.Nodes[index].Nodes[0].SelectedImageIndex = 2;

            treeNode.Expand();
            treeNode.Nodes[index].Expand();
            TreeViewer.SelectedNode = treeNode.Nodes[index];
            TreeViewer.Select();
        }

        private void AddText(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            Element parent = (Element)treeNode.Tag;
            Text text = new Text("Text");
            parent.Children.Add(text);

            treeNode.Expand();
            TreeViewer.SelectedNode = AddToTreeView(text, treeNode);
            TreeViewer.Select();
        }

        private void AddComment(object sender, EventArgs e)
        {
            TreeNode treeNode = TreeViewer.SelectedNode;
            Element parent = (Element)treeNode.Tag;
            Comment comment = new Comment("Comment");
            parent.Children.Add(comment);

            treeNode.Expand();
            TreeViewer.SelectedNode = AddToTreeView(comment, treeNode);
            TreeViewer.Select();
        }

        private void EditEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                editBox.Text = editBox.Text.Replace("\n", "");
                EditValue();
                TreeViewer.Select();
            }
        }

        private void ShowPreview(object sender, EventArgs e)
        {
            string filePath = Directory.GetCurrentDirectory() + "/temp.html";
            File.WriteAllText(filePath, serializer.Serialize(root));
            System.Diagnostics.Process.Start(filePath);
        }

        private void DeleteTempFile(object sender, FormClosingEventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + "/temp.html");
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

        public Element(string tagName)
        {
            TagName = tagName;
        }

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

    public class Comment : Node
    {
        public string Value;
        public Comment(string t)
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
        bool lastNodeElement = true;

        private bool isSelfClosing(string name)
        {
            return selfClosingTags.Contains(name);
        }

        private void AddToOutput(Node node) //htmlText
        {
            if (node is Element)
            {
                lastNodeElement = true;
                output += Environment.NewLine;
                output += new String('\t', indent);
                Element element = (Element)node;

                //Otvirajici tag + attributy
                output += $"<{element.TagName}";
                foreach(Attribute attribute in element.Attributes)
                {
                    output += $" {attribute.Name}=\"{attribute.Value}\"";
                }
                output += ">";


                if (!isSelfClosing(element.TagName))
                {
                    //Vyjimka: pokud ma element pouze jedno dite a to Text (<b>Priklad</b>), pro citelnost vystupu napiseme cely element na jeden radek.
                    if (element.Children.Count == 1 && element.Children[0] is Text)
                    {
                        Text text = (Text)element.Children[0];
                        output += text.Value;
                        output += $"</{element.TagName}>";
                    }
                    else
                    {
                        //Deti
                        indent++;
                        foreach (Node child in element.Children)
                        {
                            AddToOutput(child);
                        }
                        indent--;

                        //Uzavirajici tag
                        output += Environment.NewLine;
                        output += new String('\t', indent);
                        output += $"</{element.TagName}>";
                    }
                }
            }
            else if (node is Text)
            {
                if (!lastNodeElement)
                {
                    output += Environment.NewLine;
                    output += new String('\t', indent);
                }
                else
                {
                    lastNodeElement = false;
                }
                Text text = (Text)node;
                output += text.Value;
            }
            else //node je Comment
            {
                output += Environment.NewLine;
                output += new String('\t', indent);
                Comment comment = (Comment)node;
                output += $"<!--{comment.Value}-->";
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
        bool includeSpace = false;

        private bool Eof()
        {
            return (pos >= input.Length);
        } //Vrati true pokud je ukazatel pos na konci vstupu.

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
            string str = "";
            while(!Eof() && condition())
            {
                str += ReadChar(true);
            }
            return str;
        }

        private void ConsumeWhitespace() //Posune ukazatel dokud nasledujici znak neni whitespace.
        {
            if (pos < input.Length)
            {
                ReadWhile(() => Char.IsWhiteSpace(ReadChar(false)));
            }
        }   

        private bool IsNameCharacter(char c) //Char.IsLetterOrDigit() minulo napr. '-'.
        {
            List<char> disallowedCharacters = new List<char>() { '=', '>', ' '};
            return !disallowedCharacters.Contains(c);
        }

        private string ReadName()
        {
            return ReadWhile(() => ( IsNameCharacter(ReadChar(false))) );
        } //Precte alfanumericky nazev tagu nebo attributu.

        private string ReadAttributeValue()
        {
            ReadChar(true); // "
            string value = ReadWhile(() => ReadChar(false) != '"');
            ReadChar(true); // "
            return value;
        } //Precte hodnotu ohranicenou uvozovkami.

        private Attribute ParseAttribute() //Precte atribut v formatu Name="Value".
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

            Element element = new Element(tagName, attributes, children);
            return element;
        }

        private Text ParseText() //Precte a vrati text do zacatku nasledujiciho elementu.
        {
            Text text = new Text( ReadWhile(() => ReadChar(false) != '<') );
            if (includeSpace)
            {
                text.Value = text.Value.Insert(0, " ");
                includeSpace = false;
            }
            return text;
        }

        private Comment ParseComment()
        {
            ReadChar(true); //<
            ReadChar(true); //!
            ReadChar(true); //-
            ReadChar(true); //-
            string str = ReadWhile(() => ReadChar(false) != '>');
            Comment comment = new Comment(str.Remove(str.Length - 3));
            ReadChar(true); //>
            return comment;
        }

        private List<Node> ParseNodes()
        {
            List<Node> nodes = new List<Node>();
            while(true)
            {
                if (!Eof())
                {
                    includeSpace = (ReadChar(false) == ' ');
                }
                ConsumeWhitespace();
                if (Eof() || input.Substring(pos, 2) == "</")
                {
                    break;
                }
                nodes.Add(ParseNode());
                includeSpace = false;
            }
            return nodes;
        }

        private Node ParseNode()
        {
            Node node = new Node();
            if (ReadChar(false) == '<') //Element
            {
                pos++;
                if (ReadChar(false) == '!')
                {
                    pos--;
                    node = ParseComment();
                }
                else
                {
                    pos--;
                    node = ParseElement();
                }
            }
            else //Text
            {
                node = ParseText();
            }
            return node;
        }

        public Node Parse() //Precte input a vrati root node, popr. prida root node pokud uz neexisture.
        {
            pos = 0;

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
