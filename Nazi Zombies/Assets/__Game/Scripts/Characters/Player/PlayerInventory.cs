using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;


namespace Player
{
	public class PlayerInventory : MonoBehaviour
	{
		// The currently equipped weapon
		[ShowInInspector,PropertyOrder(-1)]
		public Weapon equippedWeapon { get; private set; }

		[SerializeField]
		private PlayerStats stats;

		[Header("Inventory"),InfoBox("The maximum size of inventory is 2")]
		public List<Weapon> weaponsList;


		public delegate void WeaponChange(Weapon weapon); //delegate
		public event WeaponChange weaponChanged; //delegate instance


		private void Awake()
		{
			if (weaponsList.Count > stats.MaxInventorySlots) Debug.LogError("Too much weapons");
			IncreaseInventorySize(stats.MaxInventorySlots);
			if (this.equippedWeapon == null) { EquipWeapon(0); }
		}

		public void AddWeaponToList(Weapon weapon)
		{
			switch (weaponsList.Count)
			{
				case 0:
					AssignWeaponToIndex(0, weapon);
					break;
				case 1:
					AssignWeaponToIndex(1, weapon);
					break;
				default:
					//overwrite equipped weapon
					AssignWeaponToIndex(weaponsList.IndexOf(equippedWeapon), weapon);
					break;
			}
		}

		private void EquipWeapon(int index)
		{
			Weapon weapon = weaponsList[index];
			if (weapon != null)
			{
				equippedWeapon = weapon;
				if (weaponChanged != null)
				{
					weaponChanged.Invoke(weapon);
				}
			}
		}

		//assign weapon to index of weapons list
		private void AssignWeaponToIndex(int index, Weapon weapon)
        {
			if (this.weaponsList[index] == null) return;
			this.weaponsList[index] = weapon;
        }

		private void IncreaseInventorySize(int size)
        {
            int slotsLeft = size - weaponsList.Count;
			if (slotsLeft < 0) return;
            for (int i = 0; i < slotsLeft; i++)
            {
				weaponsList.Add(null);
            }
		}
	}
}

