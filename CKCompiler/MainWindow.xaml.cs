using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Core;
using CKCompiler.Tokens;
using Microsoft.Win32;

namespace CKCompiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            LangTokens.Load("CKLexer.tokens");
        }

        private void FileOpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().Value)
            {
                TextEditor.Clear();
                var fileContent = File.ReadAllText(dialog.FileName);
                TextEditor.AppendText(fileContent);
            }
        }

        private void PreCompileReset()
        {
            ErrorExpander.IsExpanded = false;
        }

        private void CompileExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PreCompileReset();

            // compile
            var compiler = new Compiler();
            compiler.Compile(null, TextEditor.Text);


            ErrorsDataGrid.ItemsSource = compiler.Errors;
            if (compiler.HasErrors)
            {
                ErrorExpander.IsExpanded = true;
            }

            // update view
            LexemDataGrid.ItemsSource = compiler.Tokens;
            if (compiler.ProgramContext != null) FillLexerAndParserTables(compiler.ProgramContext);
        }

        private void FillLexerAndParserTables(IParseTree tree)
        {
            TrvSyntaxTree.Items.Clear();
            FillLexerAndParserTables(tree, null);
        }

        private void FillLexerAndParserTables(IParseTree tree, TreeViewItem parentTreeViewItem)
        {
            if (tree != null)
                for (int i = 0; i < tree.ChildCount; i++)
                {
                    var curItem = tree.GetChild(i);
                    var curToken = curItem.Payload as IToken;
                    var headerText = curToken != null ? curToken.Text : curItem.Payload.GetType().Name;

                    var item = new TreeViewItem { Header = headerText, Tag = curItem };
                    if (parentTreeViewItem == null)
                        TrvSyntaxTree.Items.Add(item);
                    else
                        parentTreeViewItem.Items.Add(item);
                    FillLexerAndParserTables(tree.GetChild(i), item);
                }
        }
    }
}
