﻿namespace VehicleRentalSystem.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using VehicleRentalSystem.Repositories.Contracts;
    using VehicleRentalSystem.Models.Vehicles.Contracts;

    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly ICollection<IVehicle> models;

        public VehicleRepository()
        {
            this.models = new HashSet<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models => (IReadOnlyCollection<IVehicle>)this.models;

        public void Add(IVehicle model) => this.models.Add(model);

        public bool Remove(IVehicle model) => this.models.Remove(model);

        public IVehicle FindByType(string type) => this.models.FirstOrDefault(m => m.GetType().Name == type)!;
    }
}
