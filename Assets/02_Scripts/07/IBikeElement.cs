using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;
    using Pattern.Visitor;

namespace Pattern.Visitor
{
        public interface IBikeElement
    {
        public void Accept(IVisitor visitor);
    }
}
