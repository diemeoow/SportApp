﻿using SportClub.Interfaces;
using SportClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.ViewModels
{
	public class EquipmentViewModel : BaseEntityViewModel<Equipment>
	{
		public EquipmentViewModel(IRepository<Equipment> repo, IJsonService json) : base(repo, json) { }

        public override async Task AddAsync()
		{
			var e = new Equipment
			{
				Name = "Новое оборудование",
				EquipmentTypeId = 6,       
				EquipmentConditionId = 4,  
				RoomId = 4
			};
			await _repo.AddAsync(e);
			await LoadAsync();
		}
	}
}
