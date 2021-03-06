﻿var dixus = (function () {
    
    var obj = {};
   
    obj.getTiposDeSuelo = function () {
        return [
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
    ]},

    obj.generarPrefijoDeSuelo = function (sueloId) {
        switch (sueloId) {
            case 1: case "1": return "VE";
            case 2: case "2": return "VS";
            case 3: case "3": return "VP";
            case 4: case "4": return "VM";
            case 5: case "5": return "VR";
            case 6: case "6": return "COM";
            case 7: case "7": return "CS";
            case 8: case "8": return "I";
            case 9: case "9": return "PAT";
            case 10: case "10": return "SE";
            case 11: case "11": return "AC";
            case 12: case "12": return "RE";
            case 13: case "13": return "EQ";
            case 14: case "14": return "DON";
            case 15: case "15": return "VIAL";
            default: return "";
        }
    }

    obj.viewModels = {};
    
    return obj;

})();