using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Controller: IController
    {
        StateContainer stateContainer;
        IModel model;
        IAction action;
        Settings settings;
        IObjectStyleSettings objectStyleSettings;

        public IModel Model
        {
            set
            {
                model = value;
            }
        }

        public Controller(IModel model)
        {
            Model = model;
            stateContainer = new StateContainer(new EmptyState((Model)model));
            action = new Action(stateContainer);
            objectStyleSettings = new ObjectStyleSettings(model);
            settings = new Settings(model,objectStyleSettings);
        }

        public IPaint PaintController
        {
            get
            {
                return model.PaintController;
            }
        }

        public ISettings Settings { get => settings; }

        public IAction Action
        {
            get
            {
                return action;
            }
        }
    }
}
