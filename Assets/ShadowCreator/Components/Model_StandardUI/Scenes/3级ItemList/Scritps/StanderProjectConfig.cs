﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace xx2 {
    public class StanderProjectConfig : ProjectBaseConfig {

        public int num;

        public StanderProjectConfig(BaseList baseList, List<BaseConfig> configs) : base(baseList, configs) {
        }

        public override void OnClick() {
            base.OnClick();
            Debug.Log("StanderProjectConfig :" + num + " OnClick");
        }
    }
}
