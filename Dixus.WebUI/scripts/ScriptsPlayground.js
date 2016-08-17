function CrearFraccionViewModel() {
    var self = this;

    self.tiposdeSuelo = [
        { id: 1, nombre: "Vivienda Economica" },
        { id: 2, nombre: "Vivienda Social" },
        { id: 3, nombre: "Vivienda Popular" },
        { id: 4, nombre: "Vivienda Media" },
        { id: 5, nombre: "Vivienda Residencial" },
        { id: 6, nombre: "Comercial" },
        { id: 7, nombre: "Comercial y Servicios" },
        { id: 8, nombre: "Industrial" },
        { id: 9, nombre: "Parque de Alta Tecnologia" },
        { id: 10, nombre: "Servicios Especiales" },
        { id: 11, nombre: "Área de Conservación" },
        { id: 12, nombre: "Reserva Estratégica" },
        { id: 13, nombre: "Equipamiento Urbano" },
        { id: 14, nombre: "Donaciones" },
        { id: 15, nombre: "Vialidad" }
    ]

    this.tipoDeSueloFueSeleccionado = ko.computed(function () {
        return self.tipoDeSuelo() ? true : false;
    }, this);

    self.tipoDeSuelo = ko.observable();

    self.esVendible = ko.computed(function () {
        return alert(self.tipoDeSuelo());
    }, this);

    self.esVivienda = ko.observable(true);
    self.esComercio = ko.observable(false);
    self.esIndustrial = ko.observable(false);
    self.esVialidad = ko.observable(false);
    self.estaVendida = ko.observable(false);
    self.seCalculaDiferente = ko.observable(false);
    self.ocupaEnergiaEspecial = ko.observable(false);
}

ko.applyBindings(new CrearFraccionViewModel());