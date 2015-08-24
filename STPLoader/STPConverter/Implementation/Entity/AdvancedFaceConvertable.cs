using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvancedFaceConvertable : IConvertable
    {
        private readonly AdvancedFace _face;
        private readonly IStpModel _model;

        public AdvancedFaceConvertable(AdvancedFace face, IStpModel model)
        {
            _face = face;
            _model = model;
            Init();
        }

        private void Init()
        {
            
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
