using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Chapter.Adapter
{
    public class InventorySystemAdapter : InventorySystem,IInventorySystem
    {
        private List<InventoryItem> _cloudInventory;

        public void SyncInventories()
        {
            var _cloudInventory = GetInventory();

            Debug.Log("클라우드와 로컬 저장소와의 인벤토리를 동기화");
        }

        public void AddItem(InventoryItem item, SaveLocation location)
        {
            if(location == SaveLocation.Cloud)
            {
                AddItem(item);
            }
            if(location == SaveLocation.Local)
            {
                Debug.Log("로컬 저장소에 아이템 추가");
            }
            if(location == SaveLocation.Both)
            {
                Debug.Log("클라우드와 로컬 저장소 모두 아이템 추가");
            }
        }

        public void RemoveItem(InventoryItem item, SaveLocation location)
        {
            Debug.Log("로컬 저장소, 클라우드 양쪽의 아이템을 삭제");
        }

        public List<InventoryItem> GetInventory(SaveLocation location)
        {
            Debug.Log("모든 저장소에서의 인벤토리 내용을 가져옴");

            return new List<InventoryItem>();
        }
    }
}
