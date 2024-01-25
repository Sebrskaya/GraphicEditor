using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Model: IModel
    {
        Scene scene;
        PaintController paintController;
        Painter painter;
        ObjectsStore objectsStore;
        Factory factory;
        SelectionStore selectionStore;
        SelectDealer selectDealer;
        LayersList layersList;
        public Model()
        {
            objectsStore = new ObjectsStore();
            painter = new Painter();
            selectionStore = new SelectionStore();
            scene = new Scene(objectsStore, painter,selectionStore);
            paintController = new PaintController(scene, painter);
            layersList = new LayersList(objectsStore, paintController);
            factory = new Factory(objectsStore, layersList);
            selectDealer = new SelectDealer(selectionStore,objectsStore, painter,factory, layersList);
        }

        public IObjectStyleSettings FactorySettings { get => factory; }
        public ICreator Creator
        {
            get
            {
                return factory;                         
            }
        }

        public IPaint PaintController
        {
            get
            {
                return paintController;
            }
        }

        public ISelectDealer SelectDealer
        {
            get
            {
                return selectDealer;
            }
        }

        public LayersList LayersList
        {
            get
            {
                return layersList;
            }
        }



    }
}
