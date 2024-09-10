using FiapBlazorDemoPreparartion.Shared.Models;

namespace FiapBlazorDemoPreparation.Services
{
    public class InMemoryStorageService
    {
        private readonly List<Shipment> _shipments = new();
        private readonly List<Container> _containers = new();
        private int _nextShipmentId = 1;
        private int _nextContainerId = 1;

        // Shipments
        public List<Shipment> GetShipments() => _shipments;

        public Shipment GetShipmentById(int id) => _shipments.FirstOrDefault(s => s.ShipmentId == id);

        public Shipment AddShipment(Shipment shipment)
        {
            shipment.ShipmentId = _nextShipmentId++;
            _shipments.Add(shipment);
            return shipment;
        }

        public bool DeleteShipment(int id)
        {
            var shipment = GetShipmentById(id);
            if (shipment != null)
            {
                _shipments.Remove(shipment);
                return true;
            }
            return false;
        }

        // Containers
        public List<Container> GetContainers() => _containers;

        public Container GetContainerById(int id) => _containers.FirstOrDefault(c => c.ContainerId == id);

        public Container AddContainer(Container container)
        {
            container.ContainerId = _nextContainerId++;
            _containers.Add(container);
            return container;
        }

        public bool DeleteContainer(int id)
        {
            var container = GetContainerById(id);
            if (container != null)
            {
                _containers.Remove(container);
                return true;
            }
            return false;
        }
    }
}
