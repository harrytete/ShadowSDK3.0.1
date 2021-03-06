﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using xx1;

public class GetConfig1 : MonoBehaviour {
    public ItemList itemList;

    public List<StanderTaskConfig> taskConfig = new List<StanderTaskConfig>();

    void Start() {
        StanderTaskConfig standerTask1Config = new StanderTaskConfig() { title = "task1", introduction = "task1描述", num = 0 };
        StanderTaskConfig standerTask2Config = new StanderTaskConfig() { title = "task2", introduction = "task2描述", num = 1 };
        StanderTaskConfig standerTask3Config = new StanderTaskConfig() { title = "task3", introduction = "task3描述", num = 2 };
        StanderTaskConfig standerTask4Config = new StanderTaskConfig() { title = "task4", introduction = "task4描述", num = 3 };
        StanderTaskConfig standerTask5Config = new StanderTaskConfig() { title = "task5", introduction = "task5描述", num = 4 };
        StanderTaskConfig standerTask6Config = new StanderTaskConfig() { title = "task6", introduction = "task6描述", num = 5 };
        StanderTaskConfig standerTask7Config = new StanderTaskConfig() { title = "task7", introduction = "task7描述", num = 6 };
        StanderTaskConfig standerTask8Config = new StanderTaskConfig() { title = "task8", introduction = "task8描述", num = 7 };
        taskConfig.Add(standerTask1Config);
        taskConfig.Add(standerTask2Config);
        taskConfig.Add(standerTask3Config);
        taskConfig.Add(standerTask4Config);
        taskConfig.Add(standerTask5Config);
        taskConfig.Add(standerTask6Config);
        taskConfig.Add(standerTask7Config);
        taskConfig.Add(standerTask8Config);

        itemList.SetTitle("StanderItemList");
        itemList.UpdateConfigs(taskConfig.Cast<BaseConfig>().ToList());
    }

}
