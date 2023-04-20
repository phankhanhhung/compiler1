using System;
namespace compiler1
{
    public class ExpressionContext
    {
        public Expression getVariablebyName(string varname)
        {
            if (varname == "var1")
                return new NumericConstant(1235);
            else
                return null;
        }

        public void printOutSomething(string strToPrint)
        {
            Console.WriteLine(strToPrint);
            
        }
    }



	public abstract class Expression
	{
        
        protected ExpressionContext m_context;
        public void SetContext(ExpressionContext context)
        {
            m_context = context;
        }
        abstract public Expression Execute();
        abstract public int GetIntValue();
        abstract public bool GetBoolValue();

    }

    public class Variable : Expression
	{
        private string v;

        public Variable(string varname)
        {
            this.v = varname;
        }

        public override Expression Execute()
        {
            return m_context.getVariablebyName(v);
        }

        public override bool GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public override int GetIntValue()
        {
            throw new NotImplementedException();
        }
    }

	public class NumericConstant : Number
    {
		public NumericConstant(int value)
		{
			my_value = value;
		}
        public override Number Execute()
        {
            return this;
        }
        public override int GetIntValue()
        {
            return base.GetIntValue();
        }

    }

    public class Number : Expression
    {
        protected int my_value;
        public override Expression Execute()
        {
            return this;
        }
        public override int GetIntValue()
        {
            return my_value;
        }
        public override bool GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public static implicit operator Number(LogicalExpression v)
        {
            throw new NotImplementedException();
        }
    }
    public class LogicalExpression : Expression
    {
        protected bool m_value;

        public LogicalExpression()
        {
        }

        public LogicalExpression(bool value)
        {
            m_value = value;
        }
        public override Expression Execute()
        {
            throw new NotImplementedException();
        }

        public override bool GetBoolValue()
        {
            return m_value;
        }

        public override int GetIntValue()
        {
            throw new NotImplementedException();
        }
    }
    public class IsGreater : LogicalExpression
    {
        Expression exp1;
        Expression exp2;

        public IsGreater(Expression value1, Expression value2) : base()
        {
            exp1 = value1;
            exp2 = value2;
        }

        public override LogicalExpression Execute()
        {
            int i1 = exp1.Execute().GetIntValue();
            int i2 = exp2.Execute().GetIntValue();
            m_value =  i1 > i2 ;
            if (m_value)
                return new  LogicalExpression(true);
            else
                return new  LogicalExpression(false);
            
        }
        public override bool GetBoolValue()
        {
            return base.GetBoolValue();
        }
    }

    
    public class ConditionedBranch : Expression
    {
        LogicalExpression m_branchingExpr;
        Expression branchTrue;
        Expression branchFalse;

        public ConditionedBranch(LogicalExpression branch, Expression branch1, Expression branch2)
        {
            m_branchingExpr = branch;
            branchTrue = branch1;
            branchFalse = branch2;
        }

        public override Expression Execute()
        {
            if (m_branchingExpr.Execute().GetBoolValue())
            {
                branchTrue.Execute();
            }
            else
            {
                branchFalse.Execute();
            }
            return this;
        }

        public override bool GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public override int GetIntValue()
        {
            throw new NotImplementedException();
        }
    }

    public class PrintOUT1 : Expression
    {
        public override Expression Execute()
        {
            m_context.printOutSomething("I am herererererere");
            return this;
        }

        public override bool GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public override int GetIntValue()
        {
            throw new NotImplementedException();
        }
    }

    public class PrintSHIT : Expression
    {
        public override Expression Execute()
        {
            m_context.printOutSomething("SHIT!!!!");
            return this;
        }

        public override bool GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public override int GetIntValue()
        {
            throw new NotImplementedException();
        }
    }
}

