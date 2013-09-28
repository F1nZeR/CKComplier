grammar CK;

options {
  language = CSharp3;
  output=AST;
  TokenLabelType=CommonToken;
  ASTLabelType=CommonTree;
}

tokens {
	ClassesList;
	Class;
	FeatureList;
	FuncDef;	
	FunctionArgsList;
	Term;
	ImplicitInvoke;
	Expr;
	InvokeExprs; // func params
	Exprs;
	LocalOrFieldInit;
	VarExprs;
}

@lexer::namespace {CKCompiler.Analyzers} 
@parser::namespace {CKCompiler.Analyzers} 

@lexer::header {#pragma warning disable 3021

using System;
using System.Text;
}

@parser::header {#pragma warning disable 3021

using System.Text;}

@rulecatch {
    catch (RecognitionException ex) {
    	DebugRecognitionException(ex);
    }
}

public program:
	(classDef)+ -> ^(ClassesList classDef+);
	
classDef: 
	CLASS typeName (COLON typeName)? LCURLY featureList RCURLY ->
		^(Class typeName featureList typeName?);
		
featureList:
	(feature)* -> ^(FeatureList feature*);
	
feature: 
 	(ID LPAREN (formalList)? RPAREN COLON typeName LCURLY expr RCURLY) -> 
 		^(FuncDef ID typeName expr formalList?)
  	| localOrFieldInit ;

formalList:
	formal (COMMA formal)* -> ^(FunctionArgsList formal+);

formal: ID COLON^ typeName;

expr:
	(ID ASSIGN^)* not;
	
not: 
	(NOT^)* relation;
	
relation:
	addition ((LE^ | LT^ | GE^ | GT^ | EQUAL^) addition)*;
	
addition:
	multiplication ((PLUS^ | MINUS^) multiplication)*;

multiplication:
	isvoid ((MULT^ | DIV^) isvoid)*;

isvoid:
	(ISVOID^)* neg;

neg:
	(NEG^)* dot;
	
dot:
	term (DOT ID LPAREN invokeExprs? RPAREN)? ->
		^(Term term ID? invokeExprs?);

term:
	  ID LPAREN invokeExprs? RPAREN -> ^(ImplicitInvoke ID invokeExprs?)
	| IF^ expr THEN! expr ELSE! expr ENDIF!
	| WHILE^ expr LOOP! expr ENDLOOP!
	| LCURLY (expr SEMI)+ RCURLY -> ^(Exprs expr+)
	| VAR! varExprs
	| NEW^ typeName
	| RETURN^ expr
	| LPAREN expr RPAREN -> ^(Expr expr)
	| ID^
	| INTEGER^
	| FLOAT^
	| STRING^
	| CHAR^
	| TRUE^
	| FALSE^
	| VOID^;

invokeExprs:
	expr (COMMA expr)* -> ^(InvokeExprs expr+);
	
varExprs:	
	localOrFieldInit (COMMA localOrFieldInit)* -> ^(VarExprs localOrFieldInit+);

localOrFieldInit:	
	ID COLON typeName (ASSIGN expr)? -> ^(LocalOrFieldInit ID typeName expr?);
	
typeName
	: IntTypeName
	| FloatTypeName
	| BoolTypeName
	| StringTypeName
	| CharTypeName
	| ObjectTypeName
	| ID;

// keywords
	CLASS : 'class';
	ELSE : 'else';
	FALSE : 'false';
	ENDIF : 'endif';
	IF : 'if';
	RETURN : 'return';
	ISVOID : 'isvoid';
	VAR : 'var';
	LOOP : 'loop';
	ENDLOOP : 'endloop';
	THEN : 'then';
	WHILE : 'while';
	NEW : 'new';
	NOT : 'not';
	TRUE : 'true';
	VOID : 'void';
	

// operators
	DOT : '.';
	NEG : '~';
	MULT : '*';
	DIV : '/';
	PLUS : '+';
	MINUS : '-';
	LE : '<=';
	LT : '<';
	GE : '>=';
	GT : '>';
	EQUAL : '==';
	ASSIGN : '=' ;
	SEMI : ';';	// razdelitel
	LPAREN : '(';
	RPAREN : ')';
	LCURLY : '{';
	RCURLY : '}';
	COMMA : ',';
	COLON : ':';
	
	IntTypeName : 'int';
	FloatTypeName : 'float';
	BoolTypeName :  'bool';
	CharTypeName : 'char';
	StringTypeName : 'string';
	ObjectTypeName : 'object';

MULTILINE_COMMENT 
	:	 '/*' .* '*/' {$channel = Hidden;} ;

STRING	:	'"'
		{ StringBuilder b = new StringBuilder(); }
		(	'"' '"'				{ b.Append('"');}
		|	c=~('"'|'\r'|'\n')	{ b.Append((char)c);}
		)*
		'"'
		{ Text = b.ToString(); }
	;

fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment DIGIT : '0'..'9';
INTEGER : DIGIT+ ;
CHAR : '\'' LETTER '\'';
FLOAT : DIGIT+ '.' DIGIT+;
ID : LETTER (LETTER | DIGIT | '_')*;
WS : (' ' | '\t' | '\n' | '\r' | '\f')+ {$channel = Hidden;};
COMMENT : '//' .* ('\n'|'\r') {$channel = Hidden;};
FALL_THROUGH
  :  .  {DebugRecognitionException(new NoViableAltException("Unknown lexem: " + Text, 5, 1, input, 1));}
  ;