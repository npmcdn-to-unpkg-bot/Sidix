dixus.viewModels.TablaFracciones = function() {
    var self = this;
    self.columnas = ko.observable('terreno');
    self.filtrosVisibles = ko.observable(false);

    self.terrenoElegido = ko.computed(function () { return self.columnas() == "terreno"; });
    self.vendiblesElegido = ko.computed(function () { return self.columnas() == "planeacion"; });
    self.finanzasElegido = ko.computed(function () { return self.columnas() == "finanzas"; });

    self.toggleFiltros = function () {
        self.filtrosVisibles(!self.filtrosVisibles());
    }

};
