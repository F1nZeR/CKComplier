using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CKCompiler.Core.Errors;
using CKCompiler.Core.ObjectDefs;

namespace CKCompiler.Core
{
    public class OptimizationGen
    {
        public ValueObjectDef GetArithmeticConstValue(ObjectDef left, ObjectDef right, IToken exprOperandToken)
        {
            var lVal = ((ValueObjectDef)left).GetValue();
            var rVal = ((ValueObjectDef)right).GetValue();
            ValueObjectDef retValue = null;

            if (left.Type == CodeGen.IntegerType)
            {
                switch (exprOperandToken.Type)
                {
                    case CKParser.PLUS:
                        retValue = new ValueObjectDef(left.Type, (int)lVal + (int)rVal);
                        break;
                    case CKParser.MINUS:
                        retValue = new ValueObjectDef(left.Type, (int)lVal - (int)rVal);
                        break;
                    case CKParser.MULT:
                        retValue = new ValueObjectDef(left.Type, (int)lVal * (int)rVal);
                        break;
                    case CKParser.DIV:
                        retValue = new ValueObjectDef(left.Type, (int)lVal / (int)rVal);
                        break;
                }
                return retValue;
            }

            if (left.Type == CodeGen.FloatType)
            {
                switch (exprOperandToken.Type)
                {
                    case CKParser.PLUS:
                        retValue = new ValueObjectDef(left.Type, (float)lVal + (float)rVal);
                        break;
                    case CKParser.MINUS:
                        retValue = new ValueObjectDef(left.Type, (float)lVal - (float)rVal);
                        break;
                    case CKParser.MULT:
                        retValue = new ValueObjectDef(left.Type, (float)lVal * (float)rVal);
                        break;
                    case CKParser.DIV:
                        retValue = new ValueObjectDef(left.Type, (float)lVal / (float)rVal);
                        break;
                }
                return retValue;
            }

            if (left.Type == CodeGen.StringType)
            {
                switch (exprOperandToken.Type)
                {
                    case CKParser.PLUS:
                        retValue = new ValueObjectDef(left.Type, (string)lVal + (string)rVal);
                        break;
                }
                return retValue;
            }

            // всегда вернёт норм значение т.к. условие извне пустит сюда только нормальные
            // но на всякий случай проверка на нулл, если будет новая операция над типами или ещё что
            if (retValue == null) throw new Exception();
            return retValue;
        }

        public ValueObjectDef GetEqualityConstValue(ObjectDef left, ObjectDef right)
        {
            return new ValueObjectDef(CodeGen.BoolType,
                ((ValueObjectDef) left).GetValue() == ((ValueObjectDef) right).GetValue());
        }

        public ValueObjectDef GetComparasionConstValue(ObjectDef left, ObjectDef right, IToken compOperator)
        {
            // приводится к double, т.к. возможные случаи: IntegerType и FloatType (тип double покроет и тот, и тот)
            var lVal = Convert.ToDouble(((ValueObjectDef)left).GetValue());
            var rVal = Convert.ToDouble(((ValueObjectDef)right).GetValue());
            ValueObjectDef retValue = null;
            
            switch (compOperator.Type)
            {
                case CKParser.LT:
                    retValue = new ValueObjectDef(CodeGen.BoolType, lVal < rVal);
                    break;
                case CKParser.LE:
                    retValue = new ValueObjectDef(CodeGen.BoolType, lVal <= rVal);
                    break;
                case CKParser.GT:
                    retValue = new ValueObjectDef(CodeGen.BoolType, lVal > rVal);
                    break;
                case CKParser.GE:
                    retValue = new ValueObjectDef(CodeGen.BoolType, lVal >= rVal);
                    break;
            }
            return retValue;
        }
    }
}
