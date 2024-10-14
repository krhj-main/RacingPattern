using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern.Visitor;

namespace Pattern.Visitor
{
    public interface IVisitor
    {
        public void Visit(IBikeElement element);
    }
}
