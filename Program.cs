

// See https://aka.ms/new-console-template for more information
using compiler1;

NumericConstant e1 = new NumericConstant(123);
Variable e2 = new Variable("var1");

LogicalExpression e = new IsGreater(e1,e2);

ExpressionContext context = new ExpressionContext();
e2.SetContext(context);

PrintOUT1 p1 = new PrintOUT1();
PrintSHIT p2 = new PrintSHIT();
p1.SetContext(context);
p2.SetContext(context);

ConditionedBranch brrrr = new ConditionedBranch(e,p1,p2);


brrrr.Execute();