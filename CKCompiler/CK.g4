grammar CK;

options {
  language = CSharp_v4_5;
}

@lexer::namespace {CKCompiler.Analyzers} 
@parser::namespace {CKCompiler.Analyzers} 

@lexer::header {#pragma warning disable 3021

using System;
using System.Text;
}

@parser::header {#pragma warning disable 3021

using System.Text;}

program :   classDef+;
	
classDef :  CLASS ID (COLON ID)? classBody;

classBody : LCURLY classBodyItem* RCURLY;
		
classBodyItem : funcDef | varDef;

varDef : VAR varDefBody (COMMA varDefBody)* SEMI;

varDefType : ID COLON (type | ID);

varDefBody : varDefType (ASSIGN expr)?;

funcDef : ID LPAREN funcArgs? RPAREN COLON (type | ID) funcBody;

funcArgs : varDefType (COMMA varDefType)*;

funcBody : block;

action : block
       | WHILE expr action
       | IF expr action ELSE action
       | RETURN expr? SEMI
       | statementExpr SEMI
       ;

statementExpr : expr;

block : LCURLY blockStatement* RCURLY;

blockStatement : action
               | varDef
               ;

expr : primary
     | expr DOT ID
     | expr LPAREN exprList? RPAREN
     | NEW ID
     | expr (MULT | DIV) expr
     | expr (PLUS | MINUS) expr
     | expr (LT | GT) expr
     | expr (ASSIGN <assoc=right>) expr
     ;

primary : LPAREN expr RPAREN
        | literal
        | ID
        ;

exprList : expr (COMMA expr)*;

literal : INTEGER
        | FLOAT
        | STRING
        | CHAR
        | TRUE
        | FALSE
        ;

type
    : IntTypeName
    | FloatTypeName
    | BoolTypeName
    | StringTypeName
    | CharTypeName
    | ObjectTypeName
    | ID
    ;

// keywords
	CLASS : 'class';
	ELSE : 'else';
	FALSE : 'false';
	IF : 'if';
	RETURN : 'return';
	VAR : 'var';
	WHILE : 'while';
	NEW : 'new';
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
	SEMI : ';';
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

STRING : '"' StringCharacters? '"';

fragment
StringCharacters
    :   StringCharacter+
    ;

fragment
StringCharacter
    :   ~["\\]
    ;

fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment DIGIT : '0'..'9';
INTEGER : DIGIT+ ;
CHAR : '\'' LETTER '\'';
FLOAT : DIGIT+ '.' DIGIT+;
ID : LETTER (LETTER | DIGIT | '_')*;
WS  :  [ \t\r\n\u000C]+ -> skip;
COMMENT : '//' ~[\r\n]* -> skip;
MULTILINE_COMMENT : '/*' .*? '*/' -> skip;
FALL_THROUGH : .+?;