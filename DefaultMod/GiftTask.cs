using GooseShared;
using SamEngine;
using System.Threading;

namespace DefaultMod {
    class GiftTask : GooseTaskInfo {
        public class TaskData : GooseTaskData { }

        public GiftTask() {
            canBePickedRandomly = true;
            shortName = "Gift Free Prize";
            description = "Click here to claim your free prize!";
            taskID = "FreePrize";
        }

        public override GooseTaskData GetNewTaskData(GooseEntity g) {
            TaskData taskData = new TaskData();
            return taskData;
        }

        public override void RunTask(GooseEntity g) {
            new Form1().Show();
            API.Goose.setCurrentTaskByID(g, API.TaskDatabase.getRandomTaskID());
        }
    }
}
