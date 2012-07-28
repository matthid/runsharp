namespace TriAxis.RunSharp.Operands
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    class MethodInfoLiteral : Operand
    {
        static MethodInfo typeofMethod = typeof(MethodBase).GetMethod("GetMethodFromHandle", new Type[]{typeof(RuntimeMethodHandle)});

        MethodInfo m;

        public MethodInfoLiteral(MethodInfo m) { this.m = m; }

        internal override void EmitGet(CodeGen g)
        {
            g.IL.Emit(OpCodes.Ldtoken, m);
            g.IL.Emit(OpCodes.Call, typeofMethod);
        }

        public override Type Type { get { return typeof(MethodInfo); } }

        internal override object ConstantValue
        {
            get
            {
                return m;
            }
        }
    }
}