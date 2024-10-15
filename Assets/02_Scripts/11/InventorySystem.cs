using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Adapter
{
    public class InventorySystem
    {
        public void AddItem(InventoryItem item)
        {
            Debug.Log("클라우드에 아이템을 추가");
        }

        public void RemoveItem(InventoryItem item)
        {
            Debug.Log("클라우드의 아이템을 삭제");
        }

        public List<InventoryItem> GetInventory()
        {
            Debug.Log("클라우드의 인벤토리 리스트를 받아옴");

            return new List<InventoryItem>();
        }
    }
}
