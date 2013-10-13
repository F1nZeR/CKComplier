// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

public partial class CKParser : Parser {
	public const int
		CLASS=1, ELSE=2, FALSE=3, IF=4, RETURN=5, VAR=6, WHILE=7, NEW=8, TRUE=9, 
		DOT=10, MULT=11, DIV=12, PLUS=13, MINUS=14, LE=15, LT=16, GE=17, GT=18, 
		EQUAL=19, NOTEQUAL=20, ASSIGN=21, SEMI=22, LBRACK=23, RBRACK=24, LPAREN=25, 
		RPAREN=26, LCURLY=27, RCURLY=28, COMMA=29, COLON=30, IntTypeName=31, FloatTypeName=32, 
		BoolTypeName=33, CharTypeName=34, StringTypeName=35, VoidTypeName=36, 
		STRING=37, INTEGER=38, CHAR=39, FLOAT=40, ID=41, WS=42, COMMENT=43, MULTILINE_COMMENT=44, 
		FALL_THROUGH=45;
	public static readonly string[] tokenNames = {
		"<INVALID>", "'class'", "'else'", "'false'", "'if'", "'return'", "'var'", 
		"'while'", "'new'", "'true'", "'.'", "'*'", "'/'", "'+'", "'-'", "'<='", 
		"'<'", "'>='", "'>'", "'=='", "'!='", "'='", "';'", "'['", "']'", "'('", 
		"')'", "'{'", "'}'", "','", "':'", "'int'", "'float'", "'bool'", "'char'", 
		"'string'", "'void'", "STRING", "INTEGER", "CHAR", "FLOAT", "ID", "WS", 
		"COMMENT", "MULTILINE_COMMENT", "FALL_THROUGH"
	};
	public const int
		RULE_program = 0, RULE_classDef = 1, RULE_classBody = 2, RULE_classBodyItem = 3, 
		RULE_varDef = 4, RULE_varDefType = 5, RULE_varDefBody = 6, RULE_funcDef = 7, 
		RULE_funcArgs = 8, RULE_funcBody = 9, RULE_action = 10, RULE_statementExpr = 11, 
		RULE_block = 12, RULE_blockStatement = 13, RULE_expr = 14, RULE_primary = 15, 
		RULE_creator = 16, RULE_exprList = 17, RULE_literal = 18, RULE_type = 19;
	public static readonly string[] ruleNames = {
		"program", "classDef", "classBody", "classBodyItem", "varDef", "varDefType", 
		"varDefBody", "funcDef", "funcArgs", "funcBody", "action", "statementExpr", 
		"block", "blockStatement", "expr", "primary", "creator", "exprList", "literal", 
		"type"
	};

	public override string GrammarFileName { get { return "CK.g4"; } }

	public override string[] TokenNames { get { return tokenNames; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public CKParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class ProgramContext : ParserRuleContext {
		public IReadOnlyList<ClassDefContext> classDef() {
			return GetRuleContexts<ClassDefContext>();
		}
		public ClassDefContext classDef(int i) {
			return GetRuleContext<ClassDefContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_program; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 41;
			_errHandler.Sync(this);
			_la = _input.La(1);
			do {
				{
				{
				State = 40; classDef();
				}
				}
				State = 43;
				_errHandler.Sync(this);
				_la = _input.La(1);
			} while ( _la==CLASS );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassDefContext : ParserRuleContext {
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public ITerminalNode CLASS() { return GetToken(CKParser.CLASS, 0); }
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public ClassBodyContext classBody() {
			return GetRuleContext<ClassBodyContext>(0);
		}
		public ClassDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassDefContext classDef() {
		ClassDefContext _localctx = new ClassDefContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_classDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 45; Match(CLASS);
			State = 46; Match(ID);
			State = 49;
			_la = _input.La(1);
			if (_la==COLON) {
				{
				State = 47; Match(COLON);
				State = 48; Match(ID);
				}
			}

			State = 51; classBody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassBodyContext : ParserRuleContext {
		public ITerminalNode LCURLY() { return GetToken(CKParser.LCURLY, 0); }
		public IReadOnlyList<ClassBodyItemContext> classBodyItem() {
			return GetRuleContexts<ClassBodyItemContext>();
		}
		public ClassBodyItemContext classBodyItem(int i) {
			return GetRuleContext<ClassBodyItemContext>(i);
		}
		public ITerminalNode RCURLY() { return GetToken(CKParser.RCURLY, 0); }
		public ClassBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassBodyContext classBody() {
		ClassBodyContext _localctx = new ClassBodyContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_classBody);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 53; Match(LCURLY);
			State = 57;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==VAR || _la==ID) {
				{
				{
				State = 54; classBodyItem();
				}
				}
				State = 59;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 60; Match(RCURLY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassBodyItemContext : ParserRuleContext {
		public FuncDefContext funcDef() {
			return GetRuleContext<FuncDefContext>(0);
		}
		public VarDefContext varDef() {
			return GetRuleContext<VarDefContext>(0);
		}
		public ClassBodyItemContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classBodyItem; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassBodyItem(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassBodyItem(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassBodyItem(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassBodyItemContext classBodyItem() {
		ClassBodyItemContext _localctx = new ClassBodyItemContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_classBodyItem);
		try {
			State = 64;
			switch (_input.La(1)) {
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 62; funcDef();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 63; varDef();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefContext : ParserRuleContext {
		public VarDefBodyContext varDefBody(int i) {
			return GetRuleContext<VarDefBodyContext>(i);
		}
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public ITerminalNode VAR() { return GetToken(CKParser.VAR, 0); }
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public IReadOnlyList<VarDefBodyContext> varDefBody() {
			return GetRuleContexts<VarDefBodyContext>();
		}
		public ITerminalNode SEMI() { return GetToken(CKParser.SEMI, 0); }
		public VarDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefContext varDef() {
		VarDefContext _localctx = new VarDefContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_varDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 66; Match(VAR);
			State = 67; varDefBody();
			State = 72;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 68; Match(COMMA);
				State = 69; varDefBody();
				}
				}
				State = 74;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 75; Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefTypeContext : ParserRuleContext {
		public ITerminalNode RBRACK() { return GetToken(CKParser.RBRACK, 0); }
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public ITerminalNode LBRACK() { return GetToken(CKParser.LBRACK, 0); }
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public VarDefTypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDefType; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDefType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDefType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDefType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefTypeContext varDefType() {
		VarDefTypeContext _localctx = new VarDefTypeContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_varDefType);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77; Match(ID);
			State = 78; Match(COLON);
			State = 81;
			switch ( Interpreter.AdaptivePredict(_input,5,_ctx) ) {
			case 1:
				{
				State = 79; type();
				}
				break;

			case 2:
				{
				State = 80; Match(ID);
				}
				break;
			}
			State = 85;
			_la = _input.La(1);
			if (_la==LBRACK) {
				{
				State = 83; Match(LBRACK);
				State = 84; Match(RBRACK);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefBodyContext : ParserRuleContext {
		public VarDefTypeContext varDefType() {
			return GetRuleContext<VarDefTypeContext>(0);
		}
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode ASSIGN() { return GetToken(CKParser.ASSIGN, 0); }
		public VarDefBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDefBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDefBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDefBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDefBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefBodyContext varDefBody() {
		VarDefBodyContext _localctx = new VarDefBodyContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_varDefBody);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87; varDefType();
			State = 90;
			_la = _input.La(1);
			if (_la==ASSIGN) {
				{
				State = 88; Match(ASSIGN);
				State = 89; expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncDefContext : ParserRuleContext {
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public FuncArgsContext funcArgs() {
			return GetRuleContext<FuncArgsContext>(0);
		}
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public FuncBodyContext funcBody() {
			return GetRuleContext<FuncBodyContext>(0);
		}
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public FuncDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncDefContext funcDef() {
		FuncDefContext _localctx = new FuncDefContext(_ctx, State);
		EnterRule(_localctx, 14, RULE_funcDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 92; Match(ID);
			State = 93; Match(LPAREN);
			State = 95;
			_la = _input.La(1);
			if (_la==ID) {
				{
				State = 94; funcArgs();
				}
			}

			State = 97; Match(RPAREN);
			State = 98; Match(COLON);
			State = 101;
			switch ( Interpreter.AdaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				State = 99; type();
				}
				break;

			case 2:
				{
				State = 100; Match(ID);
				}
				break;
			}
			State = 103; funcBody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncArgsContext : ParserRuleContext {
		public IReadOnlyList<VarDefTypeContext> varDefType() {
			return GetRuleContexts<VarDefTypeContext>();
		}
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public VarDefTypeContext varDefType(int i) {
			return GetRuleContext<VarDefTypeContext>(i);
		}
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public FuncArgsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcArgs; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncArgs(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncArgs(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncArgs(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncArgsContext funcArgs() {
		FuncArgsContext _localctx = new FuncArgsContext(_ctx, State);
		EnterRule(_localctx, 16, RULE_funcArgs);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 105; varDefType();
			State = 110;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 106; Match(COMMA);
				State = 107; varDefType();
				}
				}
				State = 112;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncBodyContext : ParserRuleContext {
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public FuncBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncBodyContext funcBody() {
		FuncBodyContext _localctx = new FuncBodyContext(_ctx, State);
		EnterRule(_localctx, 18, RULE_funcBody);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 113; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ActionContext : ParserRuleContext {
		public ActionContext action(int i) {
			return GetRuleContext<ActionContext>(i);
		}
		public StatementExprContext statementExpr() {
			return GetRuleContext<StatementExprContext>(0);
		}
		public ITerminalNode WHILE() { return GetToken(CKParser.WHILE, 0); }
		public IReadOnlyList<ActionContext> action() {
			return GetRuleContexts<ActionContext>();
		}
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public ITerminalNode SEMI() { return GetToken(CKParser.SEMI, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode ELSE() { return GetToken(CKParser.ELSE, 0); }
		public ITerminalNode IF() { return GetToken(CKParser.IF, 0); }
		public ITerminalNode RETURN() { return GetToken(CKParser.RETURN, 0); }
		public ActionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_action; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterAction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitAction(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAction(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ActionContext action() {
		ActionContext _localctx = new ActionContext(_ctx, State);
		EnterRule(_localctx, 20, RULE_action);
		int _la;
		try {
			State = 135;
			switch (_input.La(1)) {
			case LCURLY:
				EnterOuterAlt(_localctx, 1);
				{
				State = 115; block();
				}
				break;
			case WHILE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 116; Match(WHILE);
				State = 117; expr(0);
				State = 118; action();
				}
				break;
			case IF:
				EnterOuterAlt(_localctx, 3);
				{
				State = 120; Match(IF);
				State = 121; expr(0);
				State = 122; action();
				State = 125;
				switch ( Interpreter.AdaptivePredict(_input,11,_ctx) ) {
				case 1:
					{
					State = 123; Match(ELSE);
					State = 124; action();
					}
					break;
				}
				}
				break;
			case RETURN:
				EnterOuterAlt(_localctx, 4);
				{
				State = 127; Match(RETURN);
				State = 129;
				_la = _input.La(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
					{
					State = 128; expr(0);
					}
				}

				State = 131; Match(SEMI);
				}
				break;
			case FALSE:
			case NEW:
			case TRUE:
			case LPAREN:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				EnterOuterAlt(_localctx, 5);
				{
				State = 132; statementExpr();
				State = 133; Match(SEMI);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementExprContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public StatementExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_statementExpr; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterStatementExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitStatementExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatementExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementExprContext statementExpr() {
		StatementExprContext _localctx = new StatementExprContext(_ctx, State);
		EnterRule(_localctx, 22, RULE_statementExpr);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 137; expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		public BlockStatementContext blockStatement(int i) {
			return GetRuleContext<BlockStatementContext>(i);
		}
		public ITerminalNode LCURLY() { return GetToken(CKParser.LCURLY, 0); }
		public IReadOnlyList<BlockStatementContext> blockStatement() {
			return GetRuleContexts<BlockStatementContext>();
		}
		public ITerminalNode RCURLY() { return GetToken(CKParser.RCURLY, 0); }
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_block; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(_ctx, State);
		EnterRule(_localctx, 24, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 139; Match(LCURLY);
			State = 143;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << IF) | (1L << RETURN) | (1L << VAR) | (1L << WHILE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << LCURLY) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
				{
				{
				State = 140; blockStatement();
				}
				}
				State = 145;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 146; Match(RCURLY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockStatementContext : ParserRuleContext {
		public ActionContext action() {
			return GetRuleContext<ActionContext>(0);
		}
		public VarDefContext varDef() {
			return GetRuleContext<VarDefContext>(0);
		}
		public BlockStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_blockStatement; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterBlockStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitBlockStatement(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlockStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockStatementContext blockStatement() {
		BlockStatementContext _localctx = new BlockStatementContext(_ctx, State);
		EnterRule(_localctx, 26, RULE_blockStatement);
		try {
			State = 150;
			switch (_input.La(1)) {
			case FALSE:
			case IF:
			case RETURN:
			case WHILE:
			case NEW:
			case TRUE:
			case LPAREN:
			case LCURLY:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 148; action();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 149; varDef();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ITerminalNode RBRACK() { return GetToken(CKParser.RBRACK, 0); }
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode GE() { return GetToken(CKParser.GE, 0); }
		public ITerminalNode LT() { return GetToken(CKParser.LT, 0); }
		public ITerminalNode LBRACK() { return GetToken(CKParser.LBRACK, 0); }
		public IReadOnlyList<ExprContext> expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ITerminalNode EQUAL() { return GetToken(CKParser.EQUAL, 0); }
		public ITerminalNode ASSIGN() { return GetToken(CKParser.ASSIGN, 0); }
		public CreatorContext creator() {
			return GetRuleContext<CreatorContext>(0);
		}
		public ITerminalNode NEW() { return GetToken(CKParser.NEW, 0); }
		public ITerminalNode GT() { return GetToken(CKParser.GT, 0); }
		public ITerminalNode PLUS() { return GetToken(CKParser.PLUS, 0); }
		public PrimaryContext primary() {
			return GetRuleContext<PrimaryContext>(0);
		}
		public ITerminalNode MULT() { return GetToken(CKParser.MULT, 0); }
		public ITerminalNode DIV() { return GetToken(CKParser.DIV, 0); }
		public ITerminalNode MINUS() { return GetToken(CKParser.MINUS, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ITerminalNode DOT() { return GetToken(CKParser.DOT, 0); }
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public ITerminalNode LE() { return GetToken(CKParser.LE, 0); }
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public ExprListContext exprList() {
			return GetRuleContext<ExprListContext>(0);
		}
		public ITerminalNode NOTEQUAL() { return GetToken(CKParser.NOTEQUAL, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_expr; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr(int _p) {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 28;
		EnterRecursionRule(_localctx, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 156;
			switch (_input.La(1)) {
			case FALSE:
			case TRUE:
			case LPAREN:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				{
				State = 153; primary();
				}
				break;
			case NEW:
				{
				State = 154; Match(NEW);
				State = 155; creator();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.Lt(-1);
			State = 189;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,19,_ctx);
			while ( _alt!=2 && _alt!=-1 ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 187;
					switch ( Interpreter.AdaptivePredict(_input,18,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 158;
						if (!(Precpred(_ctx, 5))) throw new FailedPredicateException(this, "Precpred(_ctx, 5)");
						State = 159;
						_la = _input.La(1);
						if ( !(_la==MULT || _la==DIV) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 160; expr(6);
						}
						break;

					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 161;
						if (!(Precpred(_ctx, 4))) throw new FailedPredicateException(this, "Precpred(_ctx, 4)");
						State = 162;
						_la = _input.La(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 163; expr(5);
						}
						break;

					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 164;
						if (!(Precpred(_ctx, 3))) throw new FailedPredicateException(this, "Precpred(_ctx, 3)");
						State = 165;
						_la = _input.La(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LE) | (1L << LT) | (1L << GE) | (1L << GT))) != 0)) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 166; expr(4);
						}
						break;

					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 167;
						if (!(Precpred(_ctx, 2))) throw new FailedPredicateException(this, "Precpred(_ctx, 2)");
						State = 168;
						_la = _input.La(1);
						if ( !(_la==EQUAL || _la==NOTEQUAL) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 169; expr(3);
						}
						break;

					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 170;
						if (!(Precpred(_ctx, 1))) throw new FailedPredicateException(this, "Precpred(_ctx, 1)");
						{
						State = 171; Match(ASSIGN);
						}
						State = 172; expr(1);
						}
						break;

					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 173;
						if (!(Precpred(_ctx, 9))) throw new FailedPredicateException(this, "Precpred(_ctx, 9)");
						State = 174; Match(DOT);
						State = 175; Match(ID);
						}
						break;

					case 7:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 176;
						if (!(Precpred(_ctx, 7))) throw new FailedPredicateException(this, "Precpred(_ctx, 7)");
						State = 177; Match(LBRACK);
						State = 178; expr(0);
						State = 179; Match(RBRACK);
						}
						break;

					case 8:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 181;
						if (!(Precpred(_ctx, 6))) throw new FailedPredicateException(this, "Precpred(_ctx, 6)");
						State = 182; Match(LPAREN);
						State = 184;
						_la = _input.La(1);
						if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
							{
							State = 183; exprList();
							}
						}

						State = 186; Match(RPAREN);
						}
						break;
					}
					} 
				}
				State = 191;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,19,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class PrimaryContext : ParserRuleContext {
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public LiteralContext literal() {
			return GetRuleContext<LiteralContext>(0);
		}
		public PrimaryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_primary; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterPrimary(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitPrimary(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimary(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrimaryContext primary() {
		PrimaryContext _localctx = new PrimaryContext(_ctx, State);
		EnterRule(_localctx, 30, RULE_primary);
		try {
			State = 198;
			switch (_input.La(1)) {
			case LPAREN:
				EnterOuterAlt(_localctx, 1);
				{
				State = 192; Match(LPAREN);
				State = 193; expr(0);
				State = 194; Match(RPAREN);
				}
				break;
			case FALSE:
			case TRUE:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 196; literal();
				}
				break;
			case ID:
				EnterOuterAlt(_localctx, 3);
				{
				State = 197; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CreatorContext : ParserRuleContext {
		public ITerminalNode RBRACK() { return GetToken(CKParser.RBRACK, 0); }
		public ITerminalNode LBRACK() { return GetToken(CKParser.LBRACK, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public CreatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_creator; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterCreator(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitCreator(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCreator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CreatorContext creator() {
		CreatorContext _localctx = new CreatorContext(_ctx, State);
		EnterRule(_localctx, 32, RULE_creator);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 200; type();
			State = 205;
			switch ( Interpreter.AdaptivePredict(_input,21,_ctx) ) {
			case 1:
				{
				State = 201; Match(LBRACK);
				State = 202; expr(0);
				State = 203; Match(RBRACK);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprListContext : ParserRuleContext {
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public IReadOnlyList<ExprContext> expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_exprList; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterExprList(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitExprList(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExprList(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprListContext exprList() {
		ExprListContext _localctx = new ExprListContext(_ctx, State);
		EnterRule(_localctx, 34, RULE_exprList);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 207; expr(0);
			State = 212;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 208; Match(COMMA);
				State = 209; expr(0);
				}
				}
				State = 214;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LiteralContext : ParserRuleContext {
		public ITerminalNode CHAR() { return GetToken(CKParser.CHAR, 0); }
		public ITerminalNode INTEGER() { return GetToken(CKParser.INTEGER, 0); }
		public ITerminalNode FLOAT() { return GetToken(CKParser.FLOAT, 0); }
		public ITerminalNode FALSE() { return GetToken(CKParser.FALSE, 0); }
		public ITerminalNode TRUE() { return GetToken(CKParser.TRUE, 0); }
		public ITerminalNode STRING() { return GetToken(CKParser.STRING, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_literal; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LiteralContext literal() {
		LiteralContext _localctx = new LiteralContext(_ctx, State);
		EnterRule(_localctx, 36, RULE_literal);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 215;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << TRUE) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		public ITerminalNode IntTypeName() { return GetToken(CKParser.IntTypeName, 0); }
		public ITerminalNode VoidTypeName() { return GetToken(CKParser.VoidTypeName, 0); }
		public ITerminalNode StringTypeName() { return GetToken(CKParser.StringTypeName, 0); }
		public ITerminalNode BoolTypeName() { return GetToken(CKParser.BoolTypeName, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ITerminalNode FloatTypeName() { return GetToken(CKParser.FloatTypeName, 0); }
		public ITerminalNode CharTypeName() { return GetToken(CKParser.CharTypeName, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_type; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(_ctx, State);
		EnterRule(_localctx, 38, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 217;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IntTypeName) | (1L << FloatTypeName) | (1L << BoolTypeName) | (1L << CharTypeName) | (1L << StringTypeName) | (1L << VoidTypeName) | (1L << ID))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 14: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(_ctx, 5);

		case 1: return Precpred(_ctx, 4);

		case 2: return Precpred(_ctx, 3);

		case 3: return Precpred(_ctx, 2);

		case 4: return Precpred(_ctx, 1);

		case 5: return Precpred(_ctx, 9);

		case 6: return Precpred(_ctx, 7);

		case 7: return Precpred(_ctx, 6);
		}
		return true;
	}

	public static readonly string _serializedATN =
		"\x5\x3/\xDE\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4"+
		"\a\t\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE"+
		"\x4\xF\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14"+
		"\t\x14\x4\x15\t\x15\x3\x2\x6\x2,\n\x2\r\x2\xE\x2-\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x5\x3\x34\n\x3\x3\x3\x3\x3\x3\x4\x3\x4\a\x4:\n\x4\f\x4\xE\x4=\v\x4"+
		"\x3\x4\x3\x4\x3\x5\x3\x5\x5\x5\x43\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\a\x6I"+
		"\n\x6\f\x6\xE\x6L\v\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x5\aT\n\a\x3\a"+
		"\x3\a\x5\aX\n\a\x3\b\x3\b\x3\b\x5\b]\n\b\x3\t\x3\t\x3\t\x5\t\x62\n\t\x3"+
		"\t\x3\t\x3\t\x3\t\x5\th\n\t\x3\t\x3\t\x3\n\x3\n\x3\n\a\no\n\n\f\n\xE\n"+
		"r\v\n\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x5\f"+
		"\x80\n\f\x3\f\x3\f\x5\f\x84\n\f\x3\f\x3\f\x3\f\x3\f\x5\f\x8A\n\f\x3\r"+
		"\x3\r\x3\xE\x3\xE\a\xE\x90\n\xE\f\xE\xE\xE\x93\v\xE\x3\xE\x3\xE\x3\xF"+
		"\x3\xF\x5\xF\x99\n\xF\x3\x10\x3\x10\x3\x10\x3\x10\x5\x10\x9F\n\x10\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x5\x10\xBB\n\x10\x3\x10\a\x10"+
		"\xBE\n\x10\f\x10\xE\x10\xC1\v\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3"+
		"\x11\x5\x11\xC9\n\x11\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x5\x12\xD0\n"+
		"\x12\x3\x13\x3\x13\x3\x13\a\x13\xD5\n\x13\f\x13\xE\x13\xD8\v\x13\x3\x14"+
		"\x3\x14\x3\x15\x3\x15\x3\x15\x2\x2\x3\x1E\x16\x2\x2\x4\x2\x6\x2\b\x2\n"+
		"\x2\f\x2\xE\x2\x10\x2\x12\x2\x14\x2\x16\x2\x18\x2\x1A\x2\x1C\x2\x1E\x2"+
		" \x2\"\x2$\x2&\x2(\x2\x2\b\x3\r\xE\x3\xF\x10\x3\x11\x14\x3\x15\x16\x5"+
		"\x5\x5\v\v\'*\x4!&++\xEA\x2+\x3\x2\x2\x2\x4/\x3\x2\x2\x2\x6\x37\x3\x2"+
		"\x2\x2\b\x42\x3\x2\x2\x2\n\x44\x3\x2\x2\x2\fO\x3\x2\x2\x2\xEY\x3\x2\x2"+
		"\x2\x10^\x3\x2\x2\x2\x12k\x3\x2\x2\x2\x14s\x3\x2\x2\x2\x16\x89\x3\x2\x2"+
		"\x2\x18\x8B\x3\x2\x2\x2\x1A\x8D\x3\x2\x2\x2\x1C\x98\x3\x2\x2\x2\x1E\x9E"+
		"\x3\x2\x2\x2 \xC8\x3\x2\x2\x2\"\xCA\x3\x2\x2\x2$\xD1\x3\x2\x2\x2&\xD9"+
		"\x3\x2\x2\x2(\xDB\x3\x2\x2\x2*,\x5\x4\x3\x2+*\x3\x2\x2\x2,-\x3\x2\x2\x2"+
		"-+\x3\x2\x2\x2-.\x3\x2\x2\x2.\x3\x3\x2\x2\x2/\x30\a\x3\x2\x2\x30\x33\a"+
		"+\x2\x2\x31\x32\a \x2\x2\x32\x34\a+\x2\x2\x33\x31\x3\x2\x2\x2\x33\x34"+
		"\x3\x2\x2\x2\x34\x35\x3\x2\x2\x2\x35\x36\x5\x6\x4\x2\x36\x5\x3\x2\x2\x2"+
		"\x37;\a\x1D\x2\x2\x38:\x5\b\x5\x2\x39\x38\x3\x2\x2\x2:=\x3\x2\x2\x2;\x39"+
		"\x3\x2\x2\x2;<\x3\x2\x2\x2<>\x3\x2\x2\x2=;\x3\x2\x2\x2>?\a\x1E\x2\x2?"+
		"\a\x3\x2\x2\x2@\x43\x5\x10\t\x2\x41\x43\x5\n\x6\x2\x42@\x3\x2\x2\x2\x42"+
		"\x41\x3\x2\x2\x2\x43\t\x3\x2\x2\x2\x44\x45\a\b\x2\x2\x45J\x5\xE\b\x2\x46"+
		"G\a\x1F\x2\x2GI\x5\xE\b\x2H\x46\x3\x2\x2\x2IL\x3\x2\x2\x2JH\x3\x2\x2\x2"+
		"JK\x3\x2\x2\x2KM\x3\x2\x2\x2LJ\x3\x2\x2\x2MN\a\x18\x2\x2N\v\x3\x2\x2\x2"+
		"OP\a+\x2\x2PS\a \x2\x2QT\x5(\x15\x2RT\a+\x2\x2SQ\x3\x2\x2\x2SR\x3\x2\x2"+
		"\x2TW\x3\x2\x2\x2UV\a\x19\x2\x2VX\a\x1A\x2\x2WU\x3\x2\x2\x2WX\x3\x2\x2"+
		"\x2X\r\x3\x2\x2\x2Y\\\x5\f\a\x2Z[\a\x17\x2\x2[]\x5\x1E\x10\x2\\Z\x3\x2"+
		"\x2\x2\\]\x3\x2\x2\x2]\xF\x3\x2\x2\x2^_\a+\x2\x2_\x61\a\x1B\x2\x2`\x62"+
		"\x5\x12\n\x2\x61`\x3\x2\x2\x2\x61\x62\x3\x2\x2\x2\x62\x63\x3\x2\x2\x2"+
		"\x63\x64\a\x1C\x2\x2\x64g\a \x2\x2\x65h\x5(\x15\x2\x66h\a+\x2\x2g\x65"+
		"\x3\x2\x2\x2g\x66\x3\x2\x2\x2hi\x3\x2\x2\x2ij\x5\x14\v\x2j\x11\x3\x2\x2"+
		"\x2kp\x5\f\a\x2lm\a\x1F\x2\x2mo\x5\f\a\x2nl\x3\x2\x2\x2or\x3\x2\x2\x2"+
		"pn\x3\x2\x2\x2pq\x3\x2\x2\x2q\x13\x3\x2\x2\x2rp\x3\x2\x2\x2st\x5\x1A\xE"+
		"\x2t\x15\x3\x2\x2\x2u\x8A\x5\x1A\xE\x2vw\a\t\x2\x2wx\x5\x1E\x10\x2xy\x5"+
		"\x16\f\x2y\x8A\x3\x2\x2\x2z{\a\x6\x2\x2{|\x5\x1E\x10\x2|\x7F\x5\x16\f"+
		"\x2}~\a\x4\x2\x2~\x80\x5\x16\f\x2\x7F}\x3\x2\x2\x2\x7F\x80\x3\x2\x2\x2"+
		"\x80\x8A\x3\x2\x2\x2\x81\x83\a\a\x2\x2\x82\x84\x5\x1E\x10\x2\x83\x82\x3"+
		"\x2\x2\x2\x83\x84\x3\x2\x2\x2\x84\x85\x3\x2\x2\x2\x85\x8A\a\x18\x2\x2"+
		"\x86\x87\x5\x18\r\x2\x87\x88\a\x18\x2\x2\x88\x8A\x3\x2\x2\x2\x89u\x3\x2"+
		"\x2\x2\x89v\x3\x2\x2\x2\x89z\x3\x2\x2\x2\x89\x81\x3\x2\x2\x2\x89\x86\x3"+
		"\x2\x2\x2\x8A\x17\x3\x2\x2\x2\x8B\x8C\x5\x1E\x10\x2\x8C\x19\x3\x2\x2\x2"+
		"\x8D\x91\a\x1D\x2\x2\x8E\x90\x5\x1C\xF\x2\x8F\x8E\x3\x2\x2\x2\x90\x93"+
		"\x3\x2\x2\x2\x91\x8F\x3\x2\x2\x2\x91\x92\x3\x2\x2\x2\x92\x94\x3\x2\x2"+
		"\x2\x93\x91\x3\x2\x2\x2\x94\x95\a\x1E\x2\x2\x95\x1B\x3\x2\x2\x2\x96\x99"+
		"\x5\x16\f\x2\x97\x99\x5\n\x6\x2\x98\x96\x3\x2\x2\x2\x98\x97\x3\x2\x2\x2"+
		"\x99\x1D\x3\x2\x2\x2\x9A\x9B\b\x10\x1\x2\x9B\x9F\x5 \x11\x2\x9C\x9D\a"+
		"\n\x2\x2\x9D\x9F\x5\"\x12\x2\x9E\x9A\x3\x2\x2\x2\x9E\x9C\x3\x2\x2\x2\x9F"+
		"\xBF\x3\x2\x2\x2\xA0\xA1\f\a\x2\x2\xA1\xA2\t\x2\x2\x2\xA2\xBE\x5\x1E\x10"+
		"\b\xA3\xA4\f\x6\x2\x2\xA4\xA5\t\x3\x2\x2\xA5\xBE\x5\x1E\x10\a\xA6\xA7"+
		"\f\x5\x2\x2\xA7\xA8\t\x4\x2\x2\xA8\xBE\x5\x1E\x10\x6\xA9\xAA\f\x4\x2\x2"+
		"\xAA\xAB\t\x5\x2\x2\xAB\xBE\x5\x1E\x10\x5\xAC\xAD\f\x3\x2\x2\xAD\xAE\a"+
		"\x17\x2\x2\xAE\xBE\x5\x1E\x10\x3\xAF\xB0\f\v\x2\x2\xB0\xB1\a\f\x2\x2\xB1"+
		"\xBE\a+\x2\x2\xB2\xB3\f\t\x2\x2\xB3\xB4\a\x19\x2\x2\xB4\xB5\x5\x1E\x10"+
		"\x2\xB5\xB6\a\x1A\x2\x2\xB6\xBE\x3\x2\x2\x2\xB7\xB8\f\b\x2\x2\xB8\xBA"+
		"\a\x1B\x2\x2\xB9\xBB\x5$\x13\x2\xBA\xB9\x3\x2\x2\x2\xBA\xBB\x3\x2\x2\x2"+
		"\xBB\xBC\x3\x2\x2\x2\xBC\xBE\a\x1C\x2\x2\xBD\xA0\x3\x2\x2\x2\xBD\xA3\x3"+
		"\x2\x2\x2\xBD\xA6\x3\x2\x2\x2\xBD\xA9\x3\x2\x2\x2\xBD\xAC\x3\x2\x2\x2"+
		"\xBD\xAF\x3\x2\x2\x2\xBD\xB2\x3\x2\x2\x2\xBD\xB7\x3\x2\x2\x2\xBE\xC1\x3"+
		"\x2\x2\x2\xBF\xBD\x3\x2\x2\x2\xBF\xC0\x3\x2\x2\x2\xC0\x1F\x3\x2\x2\x2"+
		"\xC1\xBF\x3\x2\x2\x2\xC2\xC3\a\x1B\x2\x2\xC3\xC4\x5\x1E\x10\x2\xC4\xC5"+
		"\a\x1C\x2\x2\xC5\xC9\x3\x2\x2\x2\xC6\xC9\x5&\x14\x2\xC7\xC9\a+\x2\x2\xC8"+
		"\xC2\x3\x2\x2\x2\xC8\xC6\x3\x2\x2\x2\xC8\xC7\x3\x2\x2\x2\xC9!\x3\x2\x2"+
		"\x2\xCA\xCF\x5(\x15\x2\xCB\xCC\a\x19\x2\x2\xCC\xCD\x5\x1E\x10\x2\xCD\xCE"+
		"\a\x1A\x2\x2\xCE\xD0\x3\x2\x2\x2\xCF\xCB\x3\x2\x2\x2\xCF\xD0\x3\x2\x2"+
		"\x2\xD0#\x3\x2\x2\x2\xD1\xD6\x5\x1E\x10\x2\xD2\xD3\a\x1F\x2\x2\xD3\xD5"+
		"\x5\x1E\x10\x2\xD4\xD2\x3\x2\x2\x2\xD5\xD8\x3\x2\x2\x2\xD6\xD4\x3\x2\x2"+
		"\x2\xD6\xD7\x3\x2\x2\x2\xD7%\x3\x2\x2\x2\xD8\xD6\x3\x2\x2\x2\xD9\xDA\t"+
		"\x6\x2\x2\xDA\'\x3\x2\x2\x2\xDB\xDC\t\a\x2\x2\xDC)\x3\x2\x2\x2\x19-\x33"+
		";\x42JSW\\\x61gp\x7F\x83\x89\x91\x98\x9E\xBA\xBD\xBF\xC8\xCF\xD6";
	public static readonly ATN _ATN =
		ATNSimulator.Deserialize(_serializedATN.ToCharArray());
}
} // namespace CKCompiler
