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
		EQUAL=19, NOTEQUAL=20, ASSIGN=21, SEMI=22, LPAREN=23, RPAREN=24, LCURLY=25, 
		RCURLY=26, COMMA=27, COLON=28, IntTypeName=29, FloatTypeName=30, BoolTypeName=31, 
		CharTypeName=32, StringTypeName=33, VoidTypeName=34, STRING=35, INTEGER=36, 
		CHAR=37, FLOAT=38, ID=39, WS=40, COMMENT=41, MULTILINE_COMMENT=42, FALL_THROUGH=43;
	public static readonly string[] tokenNames = {
		"<INVALID>", "'class'", "'else'", "'false'", "'if'", "'return'", "'var'", 
		"'while'", "'new'", "'true'", "'.'", "'*'", "'/'", "'+'", "'-'", "'<='", 
		"'<'", "'>='", "'>'", "'=='", "'!='", "'='", "';'", "'('", "')'", "'{'", 
		"'}'", "','", "':'", "'int'", "'float'", "'bool'", "'char'", "'string'", 
		"'void'", "STRING", "INTEGER", "CHAR", "FLOAT", "ID", "WS", "COMMENT", 
		"MULTILINE_COMMENT", "FALL_THROUGH"
	};
	public const int
		RULE_program = 0, RULE_classDef = 1, RULE_classBody = 2, RULE_classBodyItem = 3, 
		RULE_varDef = 4, RULE_varDefType = 5, RULE_varDefBody = 6, RULE_funcDef = 7, 
		RULE_funcArgs = 8, RULE_funcBody = 9, RULE_action = 10, RULE_statementExpr = 11, 
		RULE_block = 12, RULE_blockStatement = 13, RULE_expr = 14, RULE_primary = 15, 
		RULE_exprList = 16, RULE_literal = 17, RULE_type = 18;
	public static readonly string[] ruleNames = {
		"program", "classDef", "classBody", "classBodyItem", "varDef", "varDefType", 
		"varDefBody", "funcDef", "funcArgs", "funcBody", "action", "statementExpr", 
		"block", "blockStatement", "expr", "primary", "exprList", "literal", "type"
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
			State = 39;
			_errHandler.Sync(this);
			_la = _input.La(1);
			do {
				{
				{
				State = 38; classDef();
				}
				}
				State = 41;
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
			State = 43; Match(CLASS);
			State = 44; Match(ID);
			State = 47;
			_la = _input.La(1);
			if (_la==COLON) {
				{
				State = 45; Match(COLON);
				State = 46; Match(ID);
				}
			}

			State = 49; classBody();
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
			State = 51; Match(LCURLY);
			State = 55;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==VAR || _la==ID) {
				{
				{
				State = 52; classBodyItem();
				}
				}
				State = 57;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 58; Match(RCURLY);
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
			State = 62;
			switch (_input.La(1)) {
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 60; funcDef();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 61; varDef();
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
			State = 64; Match(VAR);
			State = 65; varDefBody();
			State = 70;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 66; Match(COMMA);
				State = 67; varDefBody();
				}
				}
				State = 72;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 73; Match(SEMI);
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
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
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
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 75; Match(ID);
			State = 76; Match(COLON);
			State = 79;
			switch ( Interpreter.AdaptivePredict(_input,5,_ctx) ) {
			case 1:
				{
				State = 77; type();
				}
				break;

			case 2:
				{
				State = 78; Match(ID);
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
			State = 81; varDefType();
			State = 84;
			_la = _input.La(1);
			if (_la==ASSIGN) {
				{
				State = 82; Match(ASSIGN);
				State = 83; expr(0);
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
			State = 86; Match(ID);
			State = 87; Match(LPAREN);
			State = 89;
			_la = _input.La(1);
			if (_la==ID) {
				{
				State = 88; funcArgs();
				}
			}

			State = 91; Match(RPAREN);
			State = 92; Match(COLON);
			State = 95;
			switch ( Interpreter.AdaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				State = 93; type();
				}
				break;

			case 2:
				{
				State = 94; Match(ID);
				}
				break;
			}
			State = 97; funcBody();
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
			State = 99; varDefType();
			State = 104;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 100; Match(COMMA);
				State = 101; varDefType();
				}
				}
				State = 106;
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
			State = 107; block();
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
			State = 129;
			switch (_input.La(1)) {
			case LCURLY:
				EnterOuterAlt(_localctx, 1);
				{
				State = 109; block();
				}
				break;
			case WHILE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 110; Match(WHILE);
				State = 111; expr(0);
				State = 112; action();
				}
				break;
			case IF:
				EnterOuterAlt(_localctx, 3);
				{
				State = 114; Match(IF);
				State = 115; expr(0);
				State = 116; action();
				State = 119;
				switch ( Interpreter.AdaptivePredict(_input,10,_ctx) ) {
				case 1:
					{
					State = 117; Match(ELSE);
					State = 118; action();
					}
					break;
				}
				}
				break;
			case RETURN:
				EnterOuterAlt(_localctx, 4);
				{
				State = 121; Match(RETURN);
				State = 123;
				_la = _input.La(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
					{
					State = 122; expr(0);
					}
				}

				State = 125; Match(SEMI);
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
				State = 126; statementExpr();
				State = 127; Match(SEMI);
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
			State = 131; expr(0);
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
			State = 133; Match(LCURLY);
			State = 137;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << IF) | (1L << RETURN) | (1L << VAR) | (1L << WHILE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << LCURLY) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
				{
				{
				State = 134; blockStatement();
				}
				}
				State = 139;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 140; Match(RCURLY);
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
			State = 144;
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
				State = 142; action();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 143; varDef();
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
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode GE() { return GetToken(CKParser.GE, 0); }
		public ITerminalNode LT() { return GetToken(CKParser.LT, 0); }
		public IReadOnlyList<ExprContext> expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ITerminalNode EQUAL() { return GetToken(CKParser.EQUAL, 0); }
		public ITerminalNode ASSIGN() { return GetToken(CKParser.ASSIGN, 0); }
		public ITerminalNode NEW() { return GetToken(CKParser.NEW, 0); }
		public ITerminalNode GT() { return GetToken(CKParser.GT, 0); }
		public ITerminalNode PLUS() { return GetToken(CKParser.PLUS, 0); }
		public PrimaryContext primary() {
			return GetRuleContext<PrimaryContext>(0);
		}
		public ITerminalNode MULT() { return GetToken(CKParser.MULT, 0); }
		public ITerminalNode DIV() { return GetToken(CKParser.DIV, 0); }
		public ITerminalNode MINUS() { return GetToken(CKParser.MINUS, 0); }
		public ITerminalNode DOT() { return GetToken(CKParser.DOT, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
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
			State = 150;
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
				State = 147; primary();
				}
				break;
			case NEW:
				{
				State = 148; Match(NEW);
				State = 149; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.Lt(-1);
			State = 178;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,18,_ctx);
			while ( _alt!=2 && _alt!=-1 ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 176;
					switch ( Interpreter.AdaptivePredict(_input,17,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 152;
						if (!(Precpred(_ctx, 5))) throw new FailedPredicateException(this, "Precpred(_ctx, 5)");
						State = 153;
						_la = _input.La(1);
						if ( !(_la==MULT || _la==DIV) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 154; expr(6);
						}
						break;

					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 155;
						if (!(Precpred(_ctx, 4))) throw new FailedPredicateException(this, "Precpred(_ctx, 4)");
						State = 156;
						_la = _input.La(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 157; expr(5);
						}
						break;

					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 158;
						if (!(Precpred(_ctx, 3))) throw new FailedPredicateException(this, "Precpred(_ctx, 3)");
						State = 159;
						_la = _input.La(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LE) | (1L << LT) | (1L << GE) | (1L << GT))) != 0)) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 160; expr(4);
						}
						break;

					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 161;
						if (!(Precpred(_ctx, 2))) throw new FailedPredicateException(this, "Precpred(_ctx, 2)");
						State = 162;
						_la = _input.La(1);
						if ( !(_la==EQUAL || _la==NOTEQUAL) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 163; expr(3);
						}
						break;

					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 164;
						if (!(Precpred(_ctx, 1))) throw new FailedPredicateException(this, "Precpred(_ctx, 1)");
						{
						State = 165; Match(ASSIGN);
						}
						State = 166; expr(1);
						}
						break;

					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 167;
						if (!(Precpred(_ctx, 8))) throw new FailedPredicateException(this, "Precpred(_ctx, 8)");
						State = 168; Match(DOT);
						State = 169; Match(ID);
						}
						break;

					case 7:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 170;
						if (!(Precpred(_ctx, 7))) throw new FailedPredicateException(this, "Precpred(_ctx, 7)");
						State = 171; Match(LPAREN);
						State = 173;
						_la = _input.La(1);
						if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
							{
							State = 172; exprList();
							}
						}

						State = 175; Match(RPAREN);
						}
						break;
					}
					} 
				}
				State = 180;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,18,_ctx);
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
			State = 187;
			switch (_input.La(1)) {
			case LPAREN:
				EnterOuterAlt(_localctx, 1);
				{
				State = 181; Match(LPAREN);
				State = 182; expr(0);
				State = 183; Match(RPAREN);
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
				State = 185; literal();
				}
				break;
			case ID:
				EnterOuterAlt(_localctx, 3);
				{
				State = 186; Match(ID);
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
		EnterRule(_localctx, 32, RULE_exprList);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 189; expr(0);
			State = 194;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 190; Match(COMMA);
				State = 191; expr(0);
				}
				}
				State = 196;
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
		EnterRule(_localctx, 34, RULE_literal);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 197;
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
		EnterRule(_localctx, 36, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 199;
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

		case 5: return Precpred(_ctx, 8);

		case 6: return Precpred(_ctx, 7);
		}
		return true;
	}

	public static readonly string _serializedATN =
		"\x5\x3-\xCC\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4"+
		"\a\t\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE"+
		"\x4\xF\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14"+
		"\t\x14\x3\x2\x6\x2*\n\x2\r\x2\xE\x2+\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3\x32"+
		"\n\x3\x3\x3\x3\x3\x3\x4\x3\x4\a\x4\x38\n\x4\f\x4\xE\x4;\v\x4\x3\x4\x3"+
		"\x4\x3\x5\x3\x5\x5\x5\x41\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\a\x6G\n\x6\f\x6"+
		"\xE\x6J\v\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x5\aR\n\a\x3\b\x3\b\x3\b"+
		"\x5\bW\n\b\x3\t\x3\t\x3\t\x5\t\\\n\t\x3\t\x3\t\x3\t\x3\t\x5\t\x62\n\t"+
		"\x3\t\x3\t\x3\n\x3\n\x3\n\a\ni\n\n\f\n\xE\nl\v\n\x3\v\x3\v\x3\f\x3\f\x3"+
		"\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x5\fz\n\f\x3\f\x3\f\x5\f~\n\f\x3"+
		"\f\x3\f\x3\f\x3\f\x5\f\x84\n\f\x3\r\x3\r\x3\xE\x3\xE\a\xE\x8A\n\xE\f\xE"+
		"\xE\xE\x8D\v\xE\x3\xE\x3\xE\x3\xF\x3\xF\x5\xF\x93\n\xF\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x5\x10\x99\n\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10"+
		"\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10"+
		"\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x5\x10\xB0\n\x10\x3\x10\a\x10\xB3"+
		"\n\x10\f\x10\xE\x10\xB6\v\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11"+
		"\x5\x11\xBE\n\x11\x3\x12\x3\x12\x3\x12\a\x12\xC3\n\x12\f\x12\xE\x12\xC6"+
		"\v\x12\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x2\x2\x3\x1E\x15\x2\x2\x4\x2"+
		"\x6\x2\b\x2\n\x2\f\x2\xE\x2\x10\x2\x12\x2\x14\x2\x16\x2\x18\x2\x1A\x2"+
		"\x1C\x2\x1E\x2 \x2\"\x2$\x2&\x2\x2\b\x3\r\xE\x3\xF\x10\x3\x11\x14\x3\x15"+
		"\x16\x5\x5\x5\v\v%(\x4\x1F$))\xD6\x2)\x3\x2\x2\x2\x4-\x3\x2\x2\x2\x6\x35"+
		"\x3\x2\x2\x2\b@\x3\x2\x2\x2\n\x42\x3\x2\x2\x2\fM\x3\x2\x2\x2\xES\x3\x2"+
		"\x2\x2\x10X\x3\x2\x2\x2\x12\x65\x3\x2\x2\x2\x14m\x3\x2\x2\x2\x16\x83\x3"+
		"\x2\x2\x2\x18\x85\x3\x2\x2\x2\x1A\x87\x3\x2\x2\x2\x1C\x92\x3\x2\x2\x2"+
		"\x1E\x98\x3\x2\x2\x2 \xBD\x3\x2\x2\x2\"\xBF\x3\x2\x2\x2$\xC7\x3\x2\x2"+
		"\x2&\xC9\x3\x2\x2\x2(*\x5\x4\x3\x2)(\x3\x2\x2\x2*+\x3\x2\x2\x2+)\x3\x2"+
		"\x2\x2+,\x3\x2\x2\x2,\x3\x3\x2\x2\x2-.\a\x3\x2\x2.\x31\a)\x2\x2/\x30\a"+
		"\x1E\x2\x2\x30\x32\a)\x2\x2\x31/\x3\x2\x2\x2\x31\x32\x3\x2\x2\x2\x32\x33"+
		"\x3\x2\x2\x2\x33\x34\x5\x6\x4\x2\x34\x5\x3\x2\x2\x2\x35\x39\a\x1B\x2\x2"+
		"\x36\x38\x5\b\x5\x2\x37\x36\x3\x2\x2\x2\x38;\x3\x2\x2\x2\x39\x37\x3\x2"+
		"\x2\x2\x39:\x3\x2\x2\x2:<\x3\x2\x2\x2;\x39\x3\x2\x2\x2<=\a\x1C\x2\x2="+
		"\a\x3\x2\x2\x2>\x41\x5\x10\t\x2?\x41\x5\n\x6\x2@>\x3\x2\x2\x2@?\x3\x2"+
		"\x2\x2\x41\t\x3\x2\x2\x2\x42\x43\a\b\x2\x2\x43H\x5\xE\b\x2\x44\x45\a\x1D"+
		"\x2\x2\x45G\x5\xE\b\x2\x46\x44\x3\x2\x2\x2GJ\x3\x2\x2\x2H\x46\x3\x2\x2"+
		"\x2HI\x3\x2\x2\x2IK\x3\x2\x2\x2JH\x3\x2\x2\x2KL\a\x18\x2\x2L\v\x3\x2\x2"+
		"\x2MN\a)\x2\x2NQ\a\x1E\x2\x2OR\x5&\x14\x2PR\a)\x2\x2QO\x3\x2\x2\x2QP\x3"+
		"\x2\x2\x2R\r\x3\x2\x2\x2SV\x5\f\a\x2TU\a\x17\x2\x2UW\x5\x1E\x10\x2VT\x3"+
		"\x2\x2\x2VW\x3\x2\x2\x2W\xF\x3\x2\x2\x2XY\a)\x2\x2Y[\a\x19\x2\x2Z\\\x5"+
		"\x12\n\x2[Z\x3\x2\x2\x2[\\\x3\x2\x2\x2\\]\x3\x2\x2\x2]^\a\x1A\x2\x2^\x61"+
		"\a\x1E\x2\x2_\x62\x5&\x14\x2`\x62\a)\x2\x2\x61_\x3\x2\x2\x2\x61`\x3\x2"+
		"\x2\x2\x62\x63\x3\x2\x2\x2\x63\x64\x5\x14\v\x2\x64\x11\x3\x2\x2\x2\x65"+
		"j\x5\f\a\x2\x66g\a\x1D\x2\x2gi\x5\f\a\x2h\x66\x3\x2\x2\x2il\x3\x2\x2\x2"+
		"jh\x3\x2\x2\x2jk\x3\x2\x2\x2k\x13\x3\x2\x2\x2lj\x3\x2\x2\x2mn\x5\x1A\xE"+
		"\x2n\x15\x3\x2\x2\x2o\x84\x5\x1A\xE\x2pq\a\t\x2\x2qr\x5\x1E\x10\x2rs\x5"+
		"\x16\f\x2s\x84\x3\x2\x2\x2tu\a\x6\x2\x2uv\x5\x1E\x10\x2vy\x5\x16\f\x2"+
		"wx\a\x4\x2\x2xz\x5\x16\f\x2yw\x3\x2\x2\x2yz\x3\x2\x2\x2z\x84\x3\x2\x2"+
		"\x2{}\a\a\x2\x2|~\x5\x1E\x10\x2}|\x3\x2\x2\x2}~\x3\x2\x2\x2~\x7F\x3\x2"+
		"\x2\x2\x7F\x84\a\x18\x2\x2\x80\x81\x5\x18\r\x2\x81\x82\a\x18\x2\x2\x82"+
		"\x84\x3\x2\x2\x2\x83o\x3\x2\x2\x2\x83p\x3\x2\x2\x2\x83t\x3\x2\x2\x2\x83"+
		"{\x3\x2\x2\x2\x83\x80\x3\x2\x2\x2\x84\x17\x3\x2\x2\x2\x85\x86\x5\x1E\x10"+
		"\x2\x86\x19\x3\x2\x2\x2\x87\x8B\a\x1B\x2\x2\x88\x8A\x5\x1C\xF\x2\x89\x88"+
		"\x3\x2\x2\x2\x8A\x8D\x3\x2\x2\x2\x8B\x89\x3\x2\x2\x2\x8B\x8C\x3\x2\x2"+
		"\x2\x8C\x8E\x3\x2\x2\x2\x8D\x8B\x3\x2\x2\x2\x8E\x8F\a\x1C\x2\x2\x8F\x1B"+
		"\x3\x2\x2\x2\x90\x93\x5\x16\f\x2\x91\x93\x5\n\x6\x2\x92\x90\x3\x2\x2\x2"+
		"\x92\x91\x3\x2\x2\x2\x93\x1D\x3\x2\x2\x2\x94\x95\b\x10\x1\x2\x95\x99\x5"+
		" \x11\x2\x96\x97\a\n\x2\x2\x97\x99\a)\x2\x2\x98\x94\x3\x2\x2\x2\x98\x96"+
		"\x3\x2\x2\x2\x99\xB4\x3\x2\x2\x2\x9A\x9B\f\a\x2\x2\x9B\x9C\t\x2\x2\x2"+
		"\x9C\xB3\x5\x1E\x10\b\x9D\x9E\f\x6\x2\x2\x9E\x9F\t\x3\x2\x2\x9F\xB3\x5"+
		"\x1E\x10\a\xA0\xA1\f\x5\x2\x2\xA1\xA2\t\x4\x2\x2\xA2\xB3\x5\x1E\x10\x6"+
		"\xA3\xA4\f\x4\x2\x2\xA4\xA5\t\x5\x2\x2\xA5\xB3\x5\x1E\x10\x5\xA6\xA7\f"+
		"\x3\x2\x2\xA7\xA8\a\x17\x2\x2\xA8\xB3\x5\x1E\x10\x3\xA9\xAA\f\n\x2\x2"+
		"\xAA\xAB\a\f\x2\x2\xAB\xB3\a)\x2\x2\xAC\xAD\f\t\x2\x2\xAD\xAF\a\x19\x2"+
		"\x2\xAE\xB0\x5\"\x12\x2\xAF\xAE\x3\x2\x2\x2\xAF\xB0\x3\x2\x2\x2\xB0\xB1"+
		"\x3\x2\x2\x2\xB1\xB3\a\x1A\x2\x2\xB2\x9A\x3\x2\x2\x2\xB2\x9D\x3\x2\x2"+
		"\x2\xB2\xA0\x3\x2\x2\x2\xB2\xA3\x3\x2\x2\x2\xB2\xA6\x3\x2\x2\x2\xB2\xA9"+
		"\x3\x2\x2\x2\xB2\xAC\x3\x2\x2\x2\xB3\xB6\x3\x2\x2\x2\xB4\xB2\x3\x2\x2"+
		"\x2\xB4\xB5\x3\x2\x2\x2\xB5\x1F\x3\x2\x2\x2\xB6\xB4\x3\x2\x2\x2\xB7\xB8"+
		"\a\x19\x2\x2\xB8\xB9\x5\x1E\x10\x2\xB9\xBA\a\x1A\x2\x2\xBA\xBE\x3\x2\x2"+
		"\x2\xBB\xBE\x5$\x13\x2\xBC\xBE\a)\x2\x2\xBD\xB7\x3\x2\x2\x2\xBD\xBB\x3"+
		"\x2\x2\x2\xBD\xBC\x3\x2\x2\x2\xBE!\x3\x2\x2\x2\xBF\xC4\x5\x1E\x10\x2\xC0"+
		"\xC1\a\x1D\x2\x2\xC1\xC3\x5\x1E\x10\x2\xC2\xC0\x3\x2\x2\x2\xC3\xC6\x3"+
		"\x2\x2\x2\xC4\xC2\x3\x2\x2\x2\xC4\xC5\x3\x2\x2\x2\xC5#\x3\x2\x2\x2\xC6"+
		"\xC4\x3\x2\x2\x2\xC7\xC8\t\x6\x2\x2\xC8%\x3\x2\x2\x2\xC9\xCA\t\a\x2\x2"+
		"\xCA\'\x3\x2\x2\x2\x17+\x31\x39@HQV[\x61jy}\x83\x8B\x92\x98\xAF\xB2\xB4"+
		"\xBD\xC4";
	public static readonly ATN _ATN =
		ATNSimulator.Deserialize(_serializedATN.ToCharArray());
}
} // namespace CKCompiler
