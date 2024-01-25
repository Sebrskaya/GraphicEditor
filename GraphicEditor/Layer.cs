using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GraphicEditor
{
    class LayersList : ListBox
    {
        PaintController paintController;
        ObjectsStore objectStore;
        private List<Layer> layers;
        private int LayersCreatedCount = 0;
        private int activeLayerIndex;
        
        //подрубить обджектсторе и удалять тварей
        

        public int ActiveLayerIndex
        {
            get { return layers[SelectedIndex].Index; }
        }

        public LayersList(ObjectsStore objectStore, PaintController paintController)
        {
            this.paintController = paintController;
            this.objectStore = objectStore;
            
            layers = new List<Layer>();
            AddLayer();
            this.SelectedIndex = 0;
            
        }

        public void AddLayer()
        {
            
            Layer layer= new Layer();
            layer.Name = Convert.ToString(LayersCreatedCount);
            layers.Add(layer);
            layer.Index = LayersCreatedCount;
            UpdateListBox();
            this.SelectedIndex = Items.Count - 1;
            LayersCreatedCount++;
        }

        public void DeleteLayer()
        {
            if (this.SelectedIndex >= 0 & this.SelectedIndex < layers.Count)
            {
                if (layers.Count == 1) //нельзя удалить единственный слой
                    return;
                if (this.SelectedIndex == 0)
                {
                    RemoveObjectsFromObjectStore(objectStore, layers[SelectedIndex].Index);
                    layers.RemoveAt(this.SelectedIndex);
                    UpdateListBox();
                    this.SelectedIndex = 0;
                    paintController.Refresh();
                    return;
                }
                int previousSelectedIndex = this.SelectedIndex;
                RemoveObjectsFromObjectStore(objectStore, layers[SelectedIndex].Index);
                layers.RemoveAt(this.SelectedIndex);
                UpdateListBox();
                this.SelectedIndex = previousSelectedIndex-1;
                paintController.Refresh();
            }
                
        }

        public void LayerVisibilityOn()
        {
            layers[this.SelectedIndex].Visibility = true;
            ChangeVisibility(true, layers[SelectedIndex].Index);
            paintController.Refresh();
        }

        public void LayerVisibilityOff()
        {
            layers[this.SelectedIndex].Visibility = false;
            ChangeVisibility(false, layers[SelectedIndex].Index);
            paintController.Refresh();
        }

        public void ChangeVisibility(bool visibility,int layerIndex)
        {
            for (int i = 0; i < objectStore.Count; i++)
                if (objectStore[i].LayerIndex == layerIndex)
                    objectStore[i].IsVisible = visibility;
        }

        public void MoveLayerUp()//это вывод на задний слой
        {
            if (this.SelectedIndex > 0 & this.SelectedIndex < layers.Count)
            {
                int previousSelectedIndex = this.SelectedIndex;
                SwapLayers(this.SelectedIndex, this.SelectedIndex - 1);
                SortObjects(layers[SelectedIndex].Index, layers[SelectedIndex-1].Index);
                UpdateListBox();
                this.SelectedIndex = previousSelectedIndex - 1;
                paintController.Refresh();
            }
        }

        public void MoveLayerDown()//это вывод на передний слой
        {
            if (this.SelectedIndex >= 0 & this.SelectedIndex < layers.Count - 1)
            {
                int previousSelectedIndex = this.SelectedIndex;
                SwapLayers(this.SelectedIndex+1, this.SelectedIndex);
                SortObjects(layers[SelectedIndex+1].Index, layers[SelectedIndex].Index);
                UpdateListBox();
                this.SelectedIndex = previousSelectedIndex + 1;
                paintController.Refresh();
            }
        }

        private void SwapLayers(int index1, int index2)
        {
            Layer temp = layers[index1];
            layers[index1] = layers[index2];
            layers[index2] = temp;
        }

        private void UpdateListBox()
        {
            Items.Clear();
            foreach (var layer in layers)
            {
                Items.Add(layer.Name);
            }
        }

        private void SortObjects(int layerIndex1, int layerIndex2)
        {
            int stopLayerIndex = 0;
            int insertLayerIndex = 0;
            int swapIndex = 0;
            int countOfInserts = 0;
            // определение Index верхнего слоя
            for (int i = objectStore.Count - 1; i > 0; i--)
            {
                if (objectStore[i].LayerIndex == layerIndex1)
                {
                    insertLayerIndex = layerIndex1;
                    stopLayerIndex = layerIndex2;
                    break;
                }
                if (objectStore[i].LayerIndex == layerIndex2)
                {
                    insertLayerIndex = layerIndex2;
                    stopLayerIndex = layerIndex1;
                    break;
                }
            }
            // нахождение начального положения нижнего слоя    
            for (int i = 0; i < objectStore.Count; i++) 
                if (objectStore[i].LayerIndex == stopLayerIndex)
                {
                    swapIndex = i;
                    break;
                }
            //перестановка местами слоёв
            for (int i = objectStore.Count-1; i > swapIndex + countOfInserts; i--)
                if (objectStore[i+countOfInserts].LayerIndex == insertLayerIndex)
                {
                    objectStore.Insert(swapIndex, objectStore[i+countOfInserts]);
                    objectStore.RemoveAt(i + countOfInserts + 1);
                    countOfInserts++;
                }
            //objectStore.Insert(0, objectStore[1]); // для теста
            //objectStore.RemoveAt(0);
            //int lol = 0;
        }

        private void RemoveObjectsFromObjectStore(ObjectsStore objectStore, int LayerIndex)
        {
            for(int i = objectStore.Count-1; i >= 0; i--) 
            {
                if (objectStore[i].LayerIndex == LayerIndex)
                    objectStore.RemoveAt(i);
            }
        }
    }
}
