using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Core;
using CKCompiler.GUI;
using CKCompiler.Tokens;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace CKCompiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Compiler _compiler = new Compiler();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            LangTokens.Load("CKLexer.tokens");
            TextEditor.TextChanged += (o, args) => Compile();
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
            ClearErrors();
            ErrorExpander.IsExpanded = false;
        }

        private void Compile()
        {
            PreCompileReset();

            _compiler.Compile(null, TextEditor.Text);

            ErrorsDataGrid.ItemsSource = _compiler.Errors;
            if (_compiler.HasErrors)
            {
                ErrorExpander.IsExpanded = true;
                foreach (var error in _compiler.Errors)
                {
                    TextEditor.TextArea.TextView.LineTransformers.Add(
                        new LineColorizer(error.Line, error.OffendingToken.StartIndex, error.OffendingToken.StopIndex + 1));
                }
            }
            LexemDataGrid.ItemsSource = _compiler.Tokens;
            if (_compiler.ProgramContext != null) FillLexerAndParserTables(_compiler.ProgramContext);
            
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

        private void ClearErrors()
        {
            var colorizers = TextEditor.TextArea.TextView.LineTransformers.OfType<LineColorizer>().ToList();
            foreach (var lineColorizer in colorizers)
            {
                TextEditor.TextArea.TextView.LineTransformers.Remove(lineColorizer);
            }
        }

        private void CompileExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _compiler = new Compiler();
            Compile();
        }

        private void GenerateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            _compiler.GenerateCode();
        }

        private void GenerateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !_compiler.HasErrors && _compiler.ProgramContext != null;
        }
    }
}
