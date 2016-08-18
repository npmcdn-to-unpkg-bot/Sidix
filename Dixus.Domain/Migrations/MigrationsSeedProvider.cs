using Dixus.Entidades;
using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Domain.Migrations
{
    public class MigrationsSeedProvider
    {
        private MyUserManager _usermanager;
        public MigrationsSeedProvider(MyUserManager _usermanager)
        {
            this._usermanager = _usermanager;
        }

        public FraccionLegal[] ObtenerSubdivisionesLegales()
        {
            return new FraccionLegal[]
            {
                new FraccionLegal()
                {
                    FraccionLegalId = 1,
                    Nombre = "F1-Prueba",
                    ClaveCatastral = "123-456",
                    EscrituraSubdivisionId = 1,
                    Estatus = EstatusDeSubdivision.Libre,
                    FechaDeInscripcion = new DateTime(2000,1,1),
                    FechaDeOtorgamiento = new DateTime(2000,1,1),
                    VolumenRPP = 1,
                    VolumenSubdivision = 1,
                    Superficie = 180586.529,
                    Observaciones = "Esta subdivision no es real (es de prueba)",
                    NumeroDeRPP = 1,
                    Descontinuada = false,
                    ProcesoDeSubdivisionId = 1
                },
                new FraccionLegal()
                {
                    FraccionLegalId = 2,
                    Nombre = "F2016",
                    ClaveCatastral = "ABCD-666",
                    EscrituraSubdivisionId = 1,
                    Estatus = EstatusDeSubdivision.Libre,
                    FechaDeInscripcion = new DateTime(2015,12,4),
                    FechaDeOtorgamiento = new DateTime(2015,12,17),
                    VolumenRPP = 10,
                    VolumenSubdivision = 15,
                    Superficie = 164329.157,
                    Observaciones = "Esta subdivision no es real (es de prueba)",
                    NumeroDeRPP = 1403,
                    Descontinuada = false,
                    ProcesoDeCompraventaId = 4
                }
            };
        }

        public Fraccion[] ObtenerFracciones()
        {
            Fraccion[] fracciones = new Fraccion[]
            {
                new FraccionViviendaEconomica(){
                    FraccionId = 1,
                    Nombre = "VE-1",
                    MetrosCuadrados = 180586.529,
                    FraccionLegalId = 1
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 2,
                    Nombre = "VE-2",
                    MetrosCuadrados = 164329.157,
                    FraccionLegalId = 2
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 3,
                    Nombre = "VE-3",
                    MetrosCuadrados = 122671.968,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 4,
                    Nombre = "VE-4",
                    MetrosCuadrados = 253019.989,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 5,
                    Nombre = "VE-4a",
                    MetrosCuadrados = 2229.302,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 6,
                    Nombre = "VE-5a",
                    MetrosCuadrados = 78244.718,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 7,
                    Nombre = "VE-5b",
                    MetrosCuadrados = 78244.717,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 8,
                    Nombre = "VE-6a",
                    MetrosCuadrados = 60000,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 9,
                    Nombre = "VE-6b",
                    MetrosCuadrados = 114701.547,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 10,
                    Nombre = "KE-01",
                    MetrosCuadrados = 1626.791,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 11,
                    Nombre = "KE-02",
                    MetrosCuadrados = 1489.557,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 12,
                    Nombre = "VE-7a",
                    MetrosCuadrados = 72438.42,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 13,
                    Nombre = "VE-7b",
                    MetrosCuadrados = 72438.418,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 14,
                    Nombre = "VE-8",
                    MetrosCuadrados = 198888.76,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 15,
                    Nombre = "VE-9",
                    MetrosCuadrados = 176581.584,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 16,
                    Nombre = "VE-10a",
                    MetrosCuadrados = 30000,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 17,
                    Nombre = "VE-10b",
                    MetrosCuadrados = 100000.035,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 18,
                    Nombre = "VE-11",
                    MetrosCuadrados = 107218.989,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 19,
                    Nombre = "VE-12ar",
                    MetrosCuadrados = 20000,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 20,
                    Nombre = "VE-12b",
                    MetrosCuadrados = 38092.798,
                },

                new FraccionViviendaEconomica(){
                    FraccionId = 21,
                    Nombre = "VE-12c",
                    MetrosCuadrados = 11907.202,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 22,
                    Nombre = "VS-1",
                    MetrosCuadrados = 100542.813,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 23,
                    Nombre = "VS-2",
                    MetrosCuadrados = 25765.813,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 24,
                    Nombre = "VS-3",
                    MetrosCuadrados = 49544.072,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 25,
                    Nombre = "VS-4",
                    MetrosCuadrados = 38887.157,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 26,
                    Nombre = "VS-4a",
                    MetrosCuadrados = 13564.232,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 27,
                    Nombre = "VS-5",
                    MetrosCuadrados = 129403.827,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 28,
                    Nombre = "VS-6",
                    MetrosCuadrados = 78496.558,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 29,
                    Nombre = "VS-7",
                    MetrosCuadrados = 85161.001,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 30,
                    Nombre = "VS-8",
                    MetrosCuadrados = 58409.38,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 31,
                    Nombre = "VS-9",
                    MetrosCuadrados = 58379.826,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 32,
                    Nombre = "VS-10",
                    MetrosCuadrados = 11659.629,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 33,
                    Nombre = "VS-11",
                    MetrosCuadrados = 37450.773,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 34,
                    Nombre = "VS-12a",
                    MetrosCuadrados = 60000,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 35,
                    Nombre = "VS-12b",
                    MetrosCuadrados = 60000,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 36,
                    Nombre = "VS-12c",
                    MetrosCuadrados = 40000,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 37,
                    Nombre = "VS-13A",
                    MetrosCuadrados = 103947.379,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 38,
                    Nombre = "VS-13B",
                    MetrosCuadrados = 60738.934,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 39,
                    Nombre = "VS-14",
                    MetrosCuadrados = 82482.054,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 40,
                    Nombre = "VS-15",
                    MetrosCuadrados = 4841.818,
                },

                new FraccionViviendaSocial(){
                    FraccionId = 41,
                    Nombre = "VS-16",
                    MetrosCuadrados = 21042.143,
                },

                new FraccionIN(){
                    FraccionId = 42,
                    Nombre = "I-15",
                    MetrosCuadrados = 101416.796,
                },

                new FraccionIN(){
                    FraccionId = 43,
                    Nombre = "I-16",
                    MetrosCuadrados = 100168.542,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 44,
                    Nombre = "VP-1",
                    MetrosCuadrados = 11897.34,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 45,
                    Nombre = "VP-2",
                    MetrosCuadrados = 9741.88,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 46,
                    Nombre = "VP-3",
                    MetrosCuadrados = 7679.91,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 47,
                    Nombre = "VP-4",
                    MetrosCuadrados = 23382.32,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 48,
                    Nombre = "VP-5",
                    MetrosCuadrados = 13447.89,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 49,
                    Nombre = "VP-6",
                    MetrosCuadrados = 17929.11,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 50,
                    Nombre = "VP-7",
                    MetrosCuadrados = 16332.15,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 51,
                    Nombre = "VP-8a1",
                    MetrosCuadrados = 79099.18,
                },

                new FraccionViviendaPopular(){
                    FraccionId = 52,
                    Nombre = "VP-8a2",
                    MetrosCuadrados = 9297.526,
                },

                new FraccionViviendaMedia(){
                    FraccionId = 53,
                    Nombre = "VM-1",
                    MetrosCuadrados = 185395.62,
                },

                new FraccionViviendaMedia(){
                    FraccionId = 54,
                    Nombre = "VM-2",
                    MetrosCuadrados = 185395.62,
                },

                new FraccionViviendaResidencial(){
                    FraccionId = 55,
                    Nombre = "VR-1",
                    MetrosCuadrados = 124188.12,
                },

                new FraccionViviendaResidencial(){
                    FraccionId = 56,
                    Nombre = "VR-2",
                    MetrosCuadrados = 124188.12,
                },

                new FraccionViviendaResidencial(){
                    FraccionId = 57,
                    Nombre = "VR-3",
                    MetrosCuadrados = 124188.12,
                },

                new FraccionViviendaResidencial(){
                    FraccionId = 58,
                    Nombre = "VR-4",
                    MetrosCuadrados = 124188.12,
                },

                new FraccionCOM(){
                    FraccionId = 59,
                    Nombre = "COM-0",
                    MetrosCuadrados = 823.108,
                },

                new FraccionCOM(){
                    FraccionId = 60,
                    Nombre = "COM-1a",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 61,
                    Nombre = "COM-1b",
                    MetrosCuadrados = 865,
                },

                new FraccionCOM(){
                    FraccionId = 62,
                    Nombre = "COM-1c",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 63,
                    Nombre = "COM-1d",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 64,
                    Nombre = "COM-1e",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 65,
                    Nombre = "COM-1f",
                    MetrosCuadrados = 1071.538,
                },

                new FraccionCOM(){
                    FraccionId = 66,
                    Nombre = "COM-1g",
                    MetrosCuadrados = 1017.709,
                },

                new FraccionCOM(){
                    FraccionId = 67,
                    Nombre = "COM-2a",
                    MetrosCuadrados = 5218.492,
                },

                new FraccionCOM(){
                    FraccionId = 68,
                    Nombre = "COM-2b",
                    MetrosCuadrados = 2818.061,
                },

                new FraccionCOM(){
                    FraccionId = 69,
                    Nombre = "COM-3a",
                    MetrosCuadrados = 1000.001,
                },

                new FraccionCOM(){
                    FraccionId = 70,
                    Nombre = "COM-3b",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 71,
                    Nombre = "COM-3b",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 72,
                    Nombre = "COM-3x",
                    MetrosCuadrados = 7776.861,
                },

                new FraccionCOM(){
                    FraccionId = 73,
                    Nombre = "COM-3y",
                    MetrosCuadrados = 3929.41,
                },

                new FraccionCOM(){
                    FraccionId = 74,
                    Nombre = "COM-4",
                    MetrosCuadrados = 7957.643,
                },

                new FraccionCOM(){
                    FraccionId = 75,
                    Nombre = "COM-5a",
                    MetrosCuadrados = 10002.681,
                },

                new FraccionCOM(){
                    FraccionId = 76,
                    Nombre = "COM-5b",
                    MetrosCuadrados = 2149.449,
                },

                new FraccionCOM(){
                    FraccionId = 77,
                    Nombre = "COM-6a",
                    MetrosCuadrados = 5000,
                },

                new FraccionCOM(){
                    FraccionId = 78,
                    Nombre = "COM-6b",
                    MetrosCuadrados = 999.999,
                },

                new FraccionCOM(){
                    FraccionId = 79,
                    Nombre = "COM-6c",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 80,
                    Nombre = "COM-6d",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 81,
                    Nombre = "COM-6e",
                    MetrosCuadrados = 1409.47,
                },

                new FraccionCOM(){
                    FraccionId = 82,
                    Nombre = "COM-6f",
                    MetrosCuadrados = 1596.388,
                },

                new FraccionCOM(){
                    FraccionId = 83,
                    Nombre = "COM-6g",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 84,
                    Nombre = "COM-6h",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 85,
                    Nombre = "COM-6i",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 86,
                    Nombre = "COM-6j",
                    MetrosCuadrados = 1000.003,
                },

                new FraccionCOM(){
                    FraccionId = 87,
                    Nombre = "COM-6k",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 88,
                    Nombre = "COM-6l",
                    MetrosCuadrados = 1769.633,
                },

                new FraccionCOM(){
                    FraccionId = 89,
                    Nombre = "COM-7",
                    MetrosCuadrados = 2104.011,
                },

                new FraccionCOM(){
                    FraccionId = 90,
                    Nombre = "COM-8a",
                    MetrosCuadrados = 1000,
                },

                new FraccionCOM(){
                    FraccionId = 91,
                    Nombre = "COM-8b",
                    MetrosCuadrados = 2015.06,
                },

                new FraccionCOM(){
                    FraccionId = 92,
                    Nombre = "COM-9",
                    MetrosCuadrados = 5671.296,
                },

                new FraccionCOM(){
                    FraccionId = 93,
                    Nombre = "COM-10",
                    MetrosCuadrados = 1741.587,
                },

                new FraccionCOM(){
                    FraccionId = 94,
                    Nombre = "COM-11",
                    MetrosCuadrados = 6892.584,
                },

                new FraccionCOM(){
                    FraccionId = 95,
                    Nombre = "COM-12",
                    MetrosCuadrados = 10000,
                },

                new FraccionCOM(){
                    FraccionId = 96,
                    Nombre = "COM-13",
                    MetrosCuadrados = 10613.887,
                },

                new FraccionCOM(){
                    FraccionId = 97,
                    Nombre = "COM-14",
                    MetrosCuadrados = 19098.438,
                },

                new FraccionCOM(){
                    FraccionId = 98,
                    Nombre = "COM-15",
                    MetrosCuadrados = 10000.002,
                },

                new FraccionCOM(){
                    FraccionId = 99,
                    Nombre = "COM-16",
                    MetrosCuadrados = 21118.611,
                },

                new FraccionCOM(){
                    FraccionId = 100,
                    Nombre = "COM-17",
                    MetrosCuadrados = 2500,
                },

                new FraccionCOM(){
                    FraccionId = 101,
                    Nombre = "COM-18",
                    MetrosCuadrados = 2500,
                },

                new FraccionCOM(){
                    FraccionId = 102,
                    Nombre = "COM-19",
                    MetrosCuadrados = 5000,
                },

                new FraccionCOM(){
                    FraccionId = 103,
                    Nombre = "COM-20",
                    MetrosCuadrados = 117413.65,
                },

                new FraccionCOM(){
                    FraccionId = 104,
                    Nombre = "COM-21",
                    MetrosCuadrados = 14686.724,
                },

                new FraccionCOM(){
                    FraccionId = 105,
                    Nombre = "COM-22",
                    MetrosCuadrados = 24600.023,
                },

                new FraccionCOM(){
                    FraccionId = 106,
                    Nombre = "COM-23",
                    MetrosCuadrados = 11688.341,
                },

                new FraccionCOM(){
                    FraccionId = 107,
                    Nombre = "COM-24",
                    MetrosCuadrados = 11369.182,
                },

                new FraccionCOM(){
                    FraccionId = 108,
                    Nombre = "COM-25",
                    MetrosCuadrados = 120556.631,
                },

                new FraccionCOM(){
                    FraccionId = 109,
                    Nombre = "COM-26",
                    MetrosCuadrados = 24432.693,
                },

                new FraccionCOM(){
                    FraccionId = 110,
                    Nombre = "COM-27",
                    MetrosCuadrados = 4450.532,
                },

                new FraccionCOM(){
                    FraccionId = 111,
                    Nombre = "COM-28",
                    MetrosCuadrados = 11321.588,
                },

                new FraccionCOM(){
                    FraccionId = 112,
                    Nombre = "COM-29",
                    MetrosCuadrados = 20969.804,
                },

                new FraccionCOM(){
                    FraccionId = 113,
                    Nombre = "COM-30",
                    MetrosCuadrados = 12634.993,
                },

                new FraccionCOM(){
                    FraccionId = 114,
                    Nombre = "COM-31",
                    MetrosCuadrados = 3450.814,
                },

                new FraccionCOM(){
                    FraccionId = 115,
                    Nombre = "COM-32",
                    MetrosCuadrados = 52592.613,
                },

                new FraccionCOM(){
                    FraccionId = 116,
                    Nombre = "COM-33",
                    MetrosCuadrados = 28029.201,
                },

                new FraccionCOM(){
                    FraccionId = 117,
                    Nombre = "COM-34",
                    MetrosCuadrados = 81283.68,
                },

                new FraccionCOM(){
                    FraccionId = 118,
                    Nombre = "COM-35",
                    MetrosCuadrados = 4346.576,
                },

                new FraccionCOM(){
                    FraccionId = 119,
                    Nombre = "COM-36",
                    MetrosCuadrados = 4500,
                },

                new FraccionCOM(){
                    FraccionId = 120,
                    Nombre = "COM-37",
                    MetrosCuadrados = 4813.022,
                },

                new FraccionCOM(){
                    FraccionId = 121,
                    Nombre = "COM-38",
                    MetrosCuadrados = 59202.048,
                },

                new FraccionCS(){
                    FraccionId = 122,
                    Nombre = "CS-1a",
                    MetrosCuadrados = 41832.013,
                },

                new FraccionCS(){
                    FraccionId = 123,
                    Nombre = "CS-1b",
                    MetrosCuadrados = 42078.633,
                },

                new FraccionCS(){
                    FraccionId = 124,
                    Nombre = "CS-2",
                    MetrosCuadrados = 6256.268,
                },

                new FraccionCS(){
                    FraccionId = 125,
                    Nombre = "CS-3",
                    MetrosCuadrados = 18056.305,
                },

                new FraccionCS(){
                    FraccionId = 126,
                    Nombre = "CS-4",
                    MetrosCuadrados = 12919.146,
                },

                new FraccionCS(){
                    FraccionId = 127,
                    Nombre = "CS5-1",
                    MetrosCuadrados = 4174.766,
                },

                new FraccionCS(){
                    FraccionId = 128,
                    Nombre = "CS5-2",
                    MetrosCuadrados = 300.133,
                },

                new FraccionCS(){
                    FraccionId = 129,
                    Nombre = "CS6-1",
                    MetrosCuadrados = 777.569,
                },

                new FraccionCS(){
                    FraccionId = 130,
                    Nombre = "CS6-2",
                    MetrosCuadrados = 940.858,
                },

                new FraccionCS(){
                    FraccionId = 131,
                    Nombre = "CS6-3",
                    MetrosCuadrados = 1683.618,
                },

                new FraccionCS(){
                    FraccionId = 132,
                    Nombre = "CS6-4",
                    MetrosCuadrados = 900,
                },

                new FraccionCS(){
                    FraccionId = 133,
                    Nombre = "CS6-7",
                    MetrosCuadrados = 6993.54,
                },

                new FraccionCS(){
                    FraccionId = 134,
                    Nombre = "CS-9",
                    MetrosCuadrados = 3215.42,
                },

                new FraccionCS(){
                    FraccionId = 135,
                    Nombre = "CS-10",
                    MetrosCuadrados = 11259.886,
                },

                new FraccionCS(){
                    FraccionId = 136,
                    Nombre = "CS-11",
                    MetrosCuadrados = 4869.01,
                },

                new FraccionCS(){
                    FraccionId = 137,
                    Nombre = "CS-12",
                    MetrosCuadrados = 5803.529,
                },

                new FraccionCS(){
                    FraccionId = 138,
                    Nombre = "CS-13A",
                    MetrosCuadrados = 10890.394,
                },

                new FraccionCS(){
                    FraccionId = 139,
                    Nombre = "CS-13B",
                    MetrosCuadrados = 9157.468,
                },

                new FraccionCS(){
                    FraccionId = 140,
                    Nombre = "CS-13C",
                    MetrosCuadrados = 9976.484,
                },

                new FraccionCS(){
                    FraccionId = 141,
                    Nombre = "CS-13D",
                    MetrosCuadrados = 17157.524,
                },

                new FraccionCS(){
                    FraccionId = 142,
                    Nombre = "CS-13E",
                    MetrosCuadrados = 20823.847,
                },

                new FraccionCS(){
                    FraccionId = 143,
                    Nombre = "CS-14",
                    MetrosCuadrados = 29488.237,
                },

                new FraccionCS(){
                    FraccionId = 144,
                    Nombre = "CS-15",
                    MetrosCuadrados = 18651.518,
                },

                new FraccionCS(){
                    FraccionId = 145,
                    Nombre = "CS-16",
                    MetrosCuadrados = 13078.084,
                },

                new FraccionCS(){
                    FraccionId = 146,
                    Nombre = "CS-17",
                    MetrosCuadrados = 24414.848,
                },

                new FraccionCS(){
                    FraccionId = 147,
                    Nombre = "CS-18",
                    MetrosCuadrados = 29643.414,
                },

                new FraccionCS(){
                    FraccionId = 148,
                    Nombre = "CS-19A",
                    MetrosCuadrados = 6750.473,
                },

                new FraccionCS(){
                    FraccionId = 149,
                    Nombre = "CS-19B",
                    MetrosCuadrados = 15252.785,
                },

                new FraccionCS(){
                    FraccionId = 150,
                    Nombre = "CS-20",
                    MetrosCuadrados = 22426.601,
                },

                new FraccionCS(){
                    FraccionId = 151,
                    Nombre = "CS-21",
                    MetrosCuadrados = 9722.729,
                },

                new FraccionCS(){
                    FraccionId = 152,
                    Nombre = "CS-22",
                    MetrosCuadrados = 9888.027,
                },

                new FraccionCS(){
                    FraccionId = 153,
                    Nombre = "CS-23",
                    MetrosCuadrados = 9546.09,
                },

                new FraccionCS(){
                    FraccionId = 154,
                    Nombre = "CS-24",
                    MetrosCuadrados = 9902.874,
                },

                new FraccionCS(){
                    FraccionId = 155,
                    Nombre = "CS-25",
                    MetrosCuadrados = 23665.195,
                },

                new FraccionCS(){
                    FraccionId = 156,
                    Nombre = "CS-26",
                    MetrosCuadrados = 16538.01,
                },

                new FraccionCS(){
                    FraccionId = 157,
                    Nombre = "CS-27",
                    MetrosCuadrados = 69351.532,
                },

                new FraccionCS(){
                    FraccionId = 158,
                    Nombre = "CS-28",
                    MetrosCuadrados = 63419.768,
                },

                new FraccionCS(){
                    FraccionId = 159,
                    Nombre = "CS-29",
                    MetrosCuadrados = 17765.756,
                },

                new FraccionCS(){
                    FraccionId = 160,
                    Nombre = "CS-30",
                    MetrosCuadrados = 52104.737,
                },

                new FraccionCS(){
                    FraccionId = 161,
                    Nombre = "CS-31",
                    MetrosCuadrados = 16959.319,
                },

                new FraccionCS(){
                    FraccionId = 162,
                    Nombre = "CS-32",
                    MetrosCuadrados = 9999.998,
                },

                new FraccionCS(){
                    FraccionId = 163,
                    Nombre = "CS-33",
                    MetrosCuadrados = 36256.401,
                },

                new FraccionCS(){
                    FraccionId = 164,
                    Nombre = "CS-34",
                    MetrosCuadrados = 21529.693,
                },

                new FraccionCS(){
                    FraccionId = 165,
                    Nombre = "CS-35",
                    MetrosCuadrados = 11150.995,
                },

                new FraccionCS(){
                    FraccionId = 166,
                    Nombre = "CS-36",
                    MetrosCuadrados = 13321.72,
                },

                new FraccionCS(){
                    FraccionId = 167,
                    Nombre = "CS-37",
                    MetrosCuadrados = 34623.668,
                },

                new FraccionCS(){
                    FraccionId = 168,
                    Nombre = "CS-38",
                    MetrosCuadrados = 23785.998,
                },

                new FraccionCS(){
                    FraccionId = 169,
                    Nombre = "CS-39",
                    MetrosCuadrados = 9022.618,
                },

                new FraccionCS(){
                    FraccionId = 170,
                    Nombre = "CS-40",
                    MetrosCuadrados = 7020.699,
                },

                new FraccionCS(){
                    FraccionId = 171,
                    Nombre = "CS-41",
                    MetrosCuadrados = 8259.506,
                },

                new FraccionCS(){
                    FraccionId = 172,
                    Nombre = "CS-42a",
                    MetrosCuadrados = 2498.85,
                },

                new FraccionCS(){
                    FraccionId = 173,
                    Nombre = "CS-42b",
                    MetrosCuadrados = 2500,
                },

                new FraccionCS(){
                    FraccionId = 174,
                    Nombre = "CS-43",
                    MetrosCuadrados = 8816.611,
                },

                new FraccionCS(){
                    FraccionId = 175,
                    Nombre = "CS-44",
                    MetrosCuadrados = 11563.862,
                },

                new FraccionCS(){
                    FraccionId = 176,
                    Nombre = "CS-45",
                    MetrosCuadrados = 10010.374,
                },

                new FraccionCS(){
                    FraccionId = 177,
                    Nombre = "CS-46",
                    MetrosCuadrados = 14624.148,
                },

                new FraccionCS(){
                    FraccionId = 178,
                    Nombre = "CS-47",
                    MetrosCuadrados = 129780.333,
                },

                new FraccionCS(){
                    FraccionId = 179,
                    Nombre = "CS-48",
                    MetrosCuadrados = 24625.06,
                },

                new FraccionCS(){
                    FraccionId = 180,
                    Nombre = "CS-49",
                    MetrosCuadrados = 27046.918,
                },

                new FraccionIN(){
                    FraccionId = 181,
                    Nombre = "I-1",
                    MetrosCuadrados = 165791.067,
                },

                new FraccionIN(){
                    FraccionId = 182,
                    Nombre = "I-2",
                    MetrosCuadrados = 70268.031,
                },

                new FraccionIN(){
                    FraccionId = 183,
                    Nombre = "I-3",
                    MetrosCuadrados = 23658.281,
                },

                new FraccionIN(){
                    FraccionId = 184,
                    Nombre = "I-4",
                    MetrosCuadrados = 122783.44,
                },

                new FraccionIN(){
                    FraccionId = 185,
                    Nombre = "I-5",
                    MetrosCuadrados = 83406.319,
                },

                new FraccionIN(){
                    FraccionId = 186,
                    Nombre = "I-6",
                    MetrosCuadrados = 34945.906,
                },

                new FraccionIN(){
                    FraccionId = 187,
                    Nombre = "I-7",
                    MetrosCuadrados = 100713.502,
                },

                new FraccionIN(){
                    FraccionId = 188,
                    Nombre = "I-8",
                    MetrosCuadrados = 23772.535,
                },

                new FraccionIN(){
                    FraccionId = 189,
                    Nombre = "I-9",
                    MetrosCuadrados = 53345.184,
                },

                new FraccionIN(){
                    FraccionId = 190,
                    Nombre = "I-10",
                    MetrosCuadrados = 69846.493,
                },

                new FraccionIN(){
                    FraccionId = 191,
                    Nombre = "I-11",
                    MetrosCuadrados = 51841.609,
                },

                new FraccionIN(){
                    FraccionId = 192,
                    Nombre = "I-12",
                    MetrosCuadrados = 45349.974,
                },

                new FraccionIN(){
                    FraccionId = 193,
                    Nombre = "I-13",
                    MetrosCuadrados = 53694.095,
                },

                new FraccionIN(){
                    FraccionId = 194,
                    Nombre = "I-14",
                    MetrosCuadrados = 116661.355,
                },

                new FraccionIN(){
                    FraccionId = 195,
                    Nombre = "I-17",
                    MetrosCuadrados = 63375.578,
                },

                new FraccionIN(){
                    FraccionId = 196,
                    Nombre = "I-18",
                    MetrosCuadrados = 66116.978,
                },

                new FraccionIN(){
                    FraccionId = 197,
                    Nombre = "I-19",
                    MetrosCuadrados = 66863.16,
                },

                new FraccionIN(){
                    FraccionId = 198,
                    Nombre = "I-20",
                    MetrosCuadrados = 61799.793,
                },

                new FraccionIN(){
                    FraccionId = 199,
                    Nombre = "I-21",
                    MetrosCuadrados = 56900.874,
                },

                new FraccionPAT(){
                    FraccionId = 200,
                    Nombre = "PAT-1",
                    MetrosCuadrados = 126076.17,
                },

                new FraccionPAT(){
                    FraccionId = 201,
                    Nombre = "PAT-2",
                    MetrosCuadrados = 191736.79,
                },

                new FraccionSE(){
                    FraccionId = 202,
                    Nombre = "SE-1",
                    MetrosCuadrados = 159709.72,
                },

                new FraccionSE(){
                    FraccionId = 203,
                    Nombre = "SE-2",
                    MetrosCuadrados = 56254.66,
                },

                new FraccionEU(){
                    FraccionId = 204,
                    Nombre = "EQ-1",
                    MetrosCuadrados = 10117.309,
                },

                new FraccionEU(){
                    FraccionId = 205,
                    Nombre = "EQ-2",
                    MetrosCuadrados = 44999.897,
                },

                new FraccionEU(){
                    FraccionId = 206,
                    Nombre = "EQ-3",
                    MetrosCuadrados = 9881.476,
                },

                new FraccionEU(){
                    FraccionId = 207,
                    Nombre = "EQ-4",
                    MetrosCuadrados = 10000.632,
                },

                new FraccionEU(){
                    FraccionId = 208,
                    Nombre = "EQ-5",
                    MetrosCuadrados = 16588.843,
                },

                new FraccionEU(){
                    FraccionId = 209,
                    Nombre = "EQ-6",
                    MetrosCuadrados = 14979.811,
                },

                new FraccionEU(){
                    FraccionId = 210,
                    Nombre = "EQ-7",
                    MetrosCuadrados = 35780.684,
                },

                new FraccionEU(){
                    FraccionId = 211,
                    Nombre = "EQ-8",
                    MetrosCuadrados = 12750.013,
                },

                new FraccionEU(){
                    FraccionId = 212,
                    Nombre = "EQ-9",
                    MetrosCuadrados = 220447.217,
                },

                new FraccionEU(){
                    FraccionId = 213,
                    Nombre = "EQ-10",
                    MetrosCuadrados = 15480.277,
                },

                new FraccionEU(){
                    FraccionId = 214,
                    Nombre = "EQ-11",
                    MetrosCuadrados = 30000,
                },

                new FraccionEU(){
                    FraccionId = 215,
                    Nombre = "EQ-12",
                    MetrosCuadrados = 7633.314,
                },

                new FraccionAC(){
                    FraccionId = 216,
                    Nombre = "AC-1",
                    MetrosCuadrados = 42215.774,
                },

                new FraccionAC(){
                    FraccionId = 217,
                    Nombre = "AC-2",
                    MetrosCuadrados = 62892.151,
                },

                new FraccionAC(){
                    FraccionId = 218,
                    Nombre = "AC-3",
                    MetrosCuadrados = 33448.62,
                },

                new FraccionAC(){
                    FraccionId = 219,
                    Nombre = "AC-4",
                    MetrosCuadrados = 5763.229,
                },

                new FraccionAC(){
                    FraccionId = 220,
                    Nombre = "AC-5",
                    MetrosCuadrados = 12582.192,
                },

                new FraccionAC(){
                    FraccionId = 221,
                    Nombre = "AC-6",
                    MetrosCuadrados = 31448.464,
                },

                new FraccionAC(){
                    FraccionId = 222,
                    Nombre = "AC-7",
                    MetrosCuadrados = 8434.686,
                },

                new FraccionAC(){
                    FraccionId = 223,
                    Nombre = "AC-8",
                    MetrosCuadrados = 43903.327,
                },

                new FraccionAC(){
                    FraccionId = 224,
                    Nombre = "AC-9",
                    MetrosCuadrados = 19581.421,
                },

                new FraccionAC(){
                    FraccionId = 225,
                    Nombre = "AC-10",
                    MetrosCuadrados = 45065.425,
                },

                new FraccionAC(){
                    FraccionId = 226,
                    Nombre = "AC-11",
                    MetrosCuadrados = 40356.64,
                },

                new FraccionAC(){
                    FraccionId = 227,
                    Nombre = "AC-12",
                    MetrosCuadrados = 19893.598,
                },

                new FraccionAC(){
                    FraccionId = 228,
                    Nombre = "AC-13",
                    MetrosCuadrados = 80774.579,
                },

                new FraccionAC(){
                    FraccionId = 229,
                    Nombre = "AC-14",
                    MetrosCuadrados = 18522.434,
                },

                new FraccionRE(){
                    FraccionId = 230,
                    Nombre = "RE-1",
                    MetrosCuadrados = 83623.911,
                },

                new FraccionRE(){
                    FraccionId = 231,
                    Nombre = "RE-2",
                    MetrosCuadrados = 135009.457,
                },

                new FraccionRE(){
                    FraccionId = 232,
                    Nombre = "RE-3",
                    MetrosCuadrados = 143659.578,
                },

                new FraccionRE(){
                    FraccionId = 233,
                    Nombre = "RE-4",
                    MetrosCuadrados = 72004.221,
                },

                new FraccionRE(){
                    FraccionId = 234,
                    Nombre = "RE-5",
                    MetrosCuadrados = 24676.474,
                },

                new FraccionRE(){
                    FraccionId = 235,
                    Nombre = "RE-6",
                    MetrosCuadrados = 33471.737,
                },

                new FraccionRE(){
                    FraccionId = 236,
                    Nombre = "RE-7",
                    MetrosCuadrados = 23689.898,
                },

                new FraccionRE(){
                    FraccionId = 237,
                    Nombre = "RE-8",
                    MetrosCuadrados = 37822.563,
                },

                new FraccionRE(){
                    FraccionId = 238,
                    Nombre = "RE-9",
                    MetrosCuadrados = 5127.935,
                },

                new FraccionRE(){
                    FraccionId = 239,
                    Nombre = "RE-10",
                    MetrosCuadrados = 2630.32,
                },

                new FraccionRE(){
                    FraccionId = 240,
                    Nombre = "RE-11",
                    MetrosCuadrados = 590.849,
                },

                new FraccionDON(){
                    FraccionId = 241,
                    Nombre = "DON-1",
                    MetrosCuadrados = 7363.435,
                },

                new FraccionDON(){
                    FraccionId = 242,
                    Nombre = "DON-2",
                    MetrosCuadrados = 511.606,
                },

                new FraccionDON(){
                    FraccionId = 243,
                    Nombre = "DON-3",
                    MetrosCuadrados = 11601.05,
                },

                new FraccionDON(){
                    FraccionId = 244,
                    Nombre = "DON-4",
                    MetrosCuadrados = 521.371,
                },

                new FraccionDON(){
                    FraccionId = 245,
                    Nombre = "DON-5",
                    MetrosCuadrados = 586.311,
                },

                new FraccionDON(){
                    FraccionId = 246,
                    Nombre = "DON-6",
                    MetrosCuadrados = 317.414,
                },

                new FraccionDON(){
                    FraccionId = 247,
                    Nombre = "DON-7",
                    MetrosCuadrados = 1064.918,
                },

                new FraccionDON(){
                    FraccionId = 248,
                    Nombre = "DON-8",
                    MetrosCuadrados = 389.713,
                },

                new FraccionDON(){
                    FraccionId = 249,
                    Nombre = "DON-9",
                    MetrosCuadrados = 2398.824,
                },

                new FraccionDON(){
                    FraccionId = 250,
                    Nombre = "DON-10",
                    MetrosCuadrados = 2996.748,
                },

                new FraccionDON(){
                    FraccionId = 251,
                    Nombre = "DON-11",
                    MetrosCuadrados = 480.004,
                },

                new FraccionDON(){
                    FraccionId = 252,
                    Nombre = "DON-12",
                    MetrosCuadrados = 6963.945,
                },

                new FraccionDON(){
                    FraccionId = 253,
                    Nombre = "DON-13",
                    MetrosCuadrados = 2806.429,
                },
                
            };
            
            foreach( var fracc in fracciones)
            {
                fracc.Geometria = DbGeometry.FromText( "POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))" , 32612);
            }

            return fracciones;
        }

        public Tarea[] ObtenerTareas()
        {
            return new Tarea[]
            {
                new ProcesoDeSubdivision()
                {
                    TareaId = 1,
                    Nombre = "Subdivision de Fraccion F1-Prueba",
                    Descripcion = "Esta es una prueba para checar el sistema de procesos del sistema SIDIX, para la cual se utilizara la subdivision de prueba F1-Prueba",
                    JuntaDeConsejoId = 3,
                    Responsables = new List<MyUser>(),
                    SolicitudParaDesarrolloUrbanoCompletada = true
                },
                new TareaBinaria()
                {
                    TareaId = 2,
                    Nombre = "Mejorar Menu Principal",
                    Descripcion = "Hacer más grande la letra del menu principal, para que sea más legible",
                    JuntaDeConsejoId = 1,
                    Responsables = new List<MyUser>(),
                    Completada = true
                },
                new TareaDePorcentaje()
                {
                    TareaId = 3,
                    Nombre = "Definir protocolos",
                    Descripcion = "Definir los procesos y protocolos que se seguirán en cada uno de los procesos incluidos en el sistema SIDIX para asegurar la veracidad y integridad de la información",
                    JuntaDeConsejoId = 1,
                    Responsables = new List<MyUser>(),
                    PorcentajeDeAvance = .39
                },
                new ProcesoDeCompraventa()
                {
                    TareaId = 4,
                    Nombre = "Compraventa de Fraccion F1-Prueba",
                    Descripcion = "Esta es una prueba para checar el sistema de procesos del sistema SIDIX, para la cual se utilizara la subdivision de prueba F1-Prueba",
                    JuntaDeConsejoId = 3,
                    Responsables = new List<MyUser>(),
                    ClienteId = 1,
                    SeEnvioDatosANotaria = true,
                    SeRecibioProyectosDeCompraventaDeNotaria = true
                },
            };
        }

        public AcuerdoDeConsejo[] ObtenerAcuerdos()
        {
            return new AcuerdoDeConsejo[]
            {
                new AcuerdoDeConsejo()
                {
                    AcuerdoDeConsejoId = 1,
                    Nombre = "Prueba",
                    Descripcion = "Este acuerdo es una muestra para probar el sistema de acuerdos",
                    JuntaDeConsejoId = 2,
                },
                
                new AcuerdoDeConsejo()
                {
                    AcuerdoDeConsejoId = 5,
                    Nombre = "Acuerdo vialidades",
                    Descripcion = "Se acordó que las calles principales serán de 4 carriles, mientas las demás serán de 2.",
                    JuntaDeConsejoId = 3
                },
                new AcuerdoDeConsejo()
                {
                    AcuerdoDeConsejoId = 7,
                    Nombre = "Calendario de uniformes",
                    Descripcion = "Se acordó que los días Lunes y Viernes se va a usar camisa de rayas y pantalon negro. Los demás días se va a usar pantalon cremita y polo azul marino.",
                    JuntaDeConsejoId = 7
                },
                new AcuerdoDeConsejo()
                {
                    AcuerdoDeConsejoId = 8,
                    Nombre = "Convenio con CFE",
                    Descripcion = "Se acordo que Dixus pagará por la infraestructura de la nueva red eléctrica.",
                    JuntaDeConsejoId = 9
                },
                new AcuerdoDeConsejo()
                {
                    AcuerdoDeConsejoId = 9,
                    Nombre = "Festejos de cumpleaños",
                    Descripcion = "Se acordó que todos los cumpleaños serán festejados con un pastel y 2 bolsas de tostitos.",
                    JuntaDeConsejoId = 8
                },
            };
        }

        public InfoInversionesEspeciales[] ObtenerInversionesEspeciales()
        {
            return new InfoInversionesEspeciales[]
            {
                new InfoInversionesEspeciales()
                {
                    Id = 1,
                    NoOcupaEnergia = true,
                    NoOcupaAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 2,
                    NoOcupaEnergia = true,
                    NoOcupaAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 3,
                    NoOcupaEnergia = true,
                    NoOcupaAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 4,
                    NoUsaEnergiaStandard = true,
                    CantidadEnergia = 1.4,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 1625009,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 5,
                    NoUsaEnergiaStandard = true,
                    CantidadEnergia = 1.4,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 1625009,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 6,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86
                },
                new InfoInversionesEspeciales()
                {
                    Id = 7,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 8,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 9,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 10,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 11,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoPagaLoMismoEnAgua = true,
                    PrecioEspecialAgua = 672519.86,
                    HizoObrasAguaAparte = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 12,
                    NoSeLeCobraEnergia = true,
                    NoSeLeCobraAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 13,
                    NoSeLeCobraEnergia = true,
                    NoSeLeCobraAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 14,
                    NoSeLeCobraEnergia = true,
                    NoSeLeCobraAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 15,
                    NoSeLeCobraEnergia = true,
                    NoSeLeCobraAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 16,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoOcupaAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 17,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.057241,
                    NoPagaLoMismoEnEnergia = true,
                    PrecioEnergia = 764130.61,
                    NoOcupaAgua = true
                },
                new InfoInversionesEspeciales()
                {
                    Id = 18,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.09950
                },
                new InfoInversionesEspeciales()
                {
                    Id = 19,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.09950
                },
                new InfoInversionesEspeciales()
                {
                    Id = 20,
                    NoUsaEnergiaStandard = true,
                    FactorDeUsoEnergia = 0.09950
                },
                new InfoInversionesEspeciales()
                {
                    Id = 21,
                    NoSeLeCobraEnergia = true,
                    NoSeLeCobraAgua = true
                }

            };
        }

        public EscrituraDeSubdivision[] ObtenerEscriturasDeSubdivision()
        {

            return new EscrituraDeSubdivision[]
            {
                new EscrituraDeSubdivision() {EscrituraId =1, NumDeSubdivision = 31967 },
                new EscrituraDeSubdivision() {EscrituraId =2, NumDeSubdivision = 32488 },
                new EscrituraDeSubdivision() {EscrituraId =3, NumDeSubdivision = 32763 },
                new EscrituraDeSubdivision() {EscrituraId =4, NumDeSubdivision = 34061 },
                new EscrituraDeSubdivision() {EscrituraId =5, NumDeSubdivision = 34449 },
                new EscrituraDeSubdivision() {EscrituraId =6, NumDeSubdivision = 34906 },
                new EscrituraDeSubdivision() {EscrituraId =7, NumDeSubdivision = 27121 },
                new EscrituraDeSubdivision() {EscrituraId =8, NumDeSubdivision = 12143 },
                new EscrituraDeSubdivision() {EscrituraId =9, NumDeSubdivision = 12174 },
                new EscrituraDeSubdivision() {EscrituraId =10, NumDeSubdivision = 32353 },
                new EscrituraDeSubdivision() {EscrituraId =11, NumDeSubdivision = 32614 },
                new EscrituraDeSubdivision() {EscrituraId =12, NumDeSubdivision = 32613 },
                new EscrituraDeSubdivision() {EscrituraId =13, NumDeSubdivision = 13163 },
                new EscrituraDeSubdivision() {EscrituraId =14, NumDeSubdivision = 13877 },
                new EscrituraDeSubdivision() {EscrituraId =15, NumDeSubdivision = 14419 },
                new EscrituraDeSubdivision() {EscrituraId =16, NumDeSubdivision = 15858 },
                new EscrituraDeSubdivision() {EscrituraId =17, NumDeSubdivision = 15859 },
                new EscrituraDeSubdivision() {EscrituraId =18, NumDeSubdivision = 15794 },
                new EscrituraDeSubdivision() {EscrituraId =19, NumDeSubdivision = 15857 },
                new EscrituraDeSubdivision() {EscrituraId =20, NumDeSubdivision = 15862 },
                new EscrituraDeSubdivision() {EscrituraId =21, NumDeSubdivision = 15861 },
                new EscrituraDeSubdivision() {EscrituraId =22, NumDeSubdivision = 15860 },
                new EscrituraDeSubdivision() {EscrituraId =23, NumDeSubdivision = 16609 },
                new EscrituraDeSubdivision() {EscrituraId =24, NumDeSubdivision = 16730 },
                new EscrituraDeSubdivision() {EscrituraId =25, NumDeSubdivision = 36002 },
                new EscrituraDeSubdivision() {EscrituraId =26, NumDeSubdivision = 17862 },
                new EscrituraDeSubdivision() {EscrituraId =27, NumDeSubdivision = 18708 },
                new EscrituraDeSubdivision() {EscrituraId =28, NumDeSubdivision = 18707 },
                new EscrituraDeSubdivision() {EscrituraId =29, NumDeSubdivision = 20225 },
                new EscrituraDeSubdivision() {EscrituraId =30, NumDeSubdivision = 20913 },
                new EscrituraDeSubdivision() {EscrituraId =31, NumDeSubdivision = 22415 },
                new EscrituraDeSubdivision() {EscrituraId =32, NumDeSubdivision = 22416 },
                new EscrituraDeSubdivision() {EscrituraId =33, NumDeSubdivision = 22417 },
                new EscrituraDeSubdivision() {EscrituraId =34, NumDeSubdivision = 22418 },
                new EscrituraDeSubdivision() {EscrituraId =35, NumDeSubdivision = 22075 },
                new EscrituraDeSubdivision() {EscrituraId =36, NumDeSubdivision = 23045 },
                new EscrituraDeSubdivision() {EscrituraId =37, NumDeSubdivision = 23440 },
                new EscrituraDeSubdivision() {EscrituraId =38, NumDeSubdivision = 23557 },
                new EscrituraDeSubdivision() {EscrituraId =39, NumDeSubdivision = 24003 },
                new EscrituraDeSubdivision() {EscrituraId =40, NumDeSubdivision = 24004 },
                new EscrituraDeSubdivision() {EscrituraId =41, NumDeSubdivision = 24294 },
                new EscrituraDeSubdivision() {EscrituraId =42, NumDeSubdivision = 24303 },
                new EscrituraDeSubdivision() {EscrituraId =43, NumDeSubdivision = 24295 },
                new EscrituraDeSubdivision() {EscrituraId =44, NumDeSubdivision = 24296 },
                new EscrituraDeSubdivision() {EscrituraId =45, NumDeSubdivision = 24297 },
                new EscrituraDeSubdivision() {EscrituraId =46, NumDeSubdivision = 42235 },
            };

        }

        public Opciones ObtenerOpciones()
        {
            return new Opciones()
            {
                OpcionesId = 1,
                NumeroDeEtapas = 3,

                ValidarSuperficieTotal = true,
                ValidarQuePoligonosEstenCerrados = true,
                ValidarQuePoligonosNoSeSobrepongan = true,
                ValidarQuePoligonosSeanValidos = true, 
                ValidarQueTodasLasGeometriasSeanPoligonos = true,
                ToleranciaEnM2ParaProyecto = 100,

                ProyectoPlanMaestroPorM2 = 1.334123236838M,
                PresupuestoYUrbanizacionPorM2 = 1.297052245869M,
                ImpactoAmbientalPorM2 = 0.25M,
                AutorizacionImpactoAmbientalPorM2 = 8M,
                RasantesAguaPotableYDrenajePorM2 = 0.55M,
                LicenciaUsoDeSueloPorM2 = 0.337330190091M,
                DeslindeDeTerrenoPorM2 = 0.674660380181M,
                EstudioTopograficoPorM2 = 0.674660380181M,
                EstudioInundabilidadPorM2 = 0.674660380181M,
                MecanicaDeSuelosPorM2 = 0.25M,
                AutorizacionPorM2 = 0.674660380181M,
                PredialesPorM2 = 1.349320760362M,

                KiloPorM2 = 11.806556653172M,
                ParquePorM2 = 16.740651947939M,
                ArborizacionPorM2 = 5.059952851359M,
                BardaPerimetralPorM2 = 11.452056356406M,
                BardaDecorativaPorM2 = 10.676622461232M,
                MurosDeContencionPorM2 = 25.772705062601M,

                UrbanizacionPorM2 = 249.433124205482M,

                PorcentajedeTUPertenecienteAGastosPorFraccionar = .05,
                PorcentajedeTUPertenecienteAInfraestructura = 0,
                PorcentajedeTUPertenecienteAObrasEspeciales = .22,
                PorcentajedeTUPertenecienteAPostVenta = .04,
                PorcentajedeTUPertenecienteATierra = .03,
                PorcentajedeTUPertenecienteAUrbanizacion = .66
            };
        }

        public TipoDeComercio[] ObtenerTiposDeComercio()
        {
            return new TipoDeComercio[]
            {
                new TipoDeComercio() { TipoDeComercioId = 1, Nombre = "Gasolinera" },
                new TipoDeComercio() { TipoDeComercioId = 2, Nombre = "Supermercado" },
                new TipoDeComercio() { TipoDeComercioId = 3, Nombre = "Abarrotes" },
                new TipoDeComercio() { TipoDeComercioId = 4, Nombre = "Papeleria" },
                new TipoDeComercio() { TipoDeComercioId = 5, Nombre = "Ferreteria" },
                new TipoDeComercio() { TipoDeComercioId = 6, Nombre = "Car Wash" },
                new TipoDeComercio() { TipoDeComercioId = 7, Nombre = "Comida Rapida" },
                new TipoDeComercio() { TipoDeComercioId = 8, Nombre = "Restaurant/Bar" }
            };
        }

        public Cliente[] ObtenerClientes()
        {

            return new Cliente[]
            {
                new Cliente() { ClienteId = 1, Nombre = "Espacio"},
                new Cliente() { ClienteId = 2, Nombre = "Derex" },
                new Cliente() { ClienteId = 3, Nombre = "Manuel Mascareñas" },
                new Cliente() { ClienteId = 4, Nombre = "OXXO" },
                new Cliente() { ClienteId = 5, Nombre = "Carlos Zaragoza" },
                new Cliente() { ClienteId = 6, Nombre = "Marcos Cubillas" },
                new Cliente() { ClienteId = 7, Nombre = "Coca-Cola" },
                new Cliente() { ClienteId = 8, Nombre = "PEMEX" },
                new Cliente() { ClienteId = 9, Nombre = "Vintel" },
                new Cliente() { ClienteId = 10, Nombre = "MGDL" },
                new Cliente() { ClienteId = 11, Nombre = "Sedes" },
                new Cliente() { ClienteId = 12, Nombre = "Gluyas" },
                new Cliente() { ClienteId = 13, Nombre = "Super del Norte" },
                new Cliente() { ClienteId = 14, Nombre = "Grupo Zarci" },
                new Cliente() { ClienteId = 15, Nombre = "Inmobiliaria Padmon" },
                new Cliente() { ClienteId = 16, Nombre = "Telecomunicaciones de Anza" },
                new Cliente() { ClienteId = 17, Nombre = "María Alejandra Barreda Mascareñas" },
                new Cliente() { ClienteId = 18, Nombre = "Marco Aurelio Barreda Mascareñas" },
                new Cliente() { ClienteId = 19, Nombre = "Municipio de Nogales" }

            };

        }

        public Inversion[] ObtenerInversiones()
        {

            return new Inversion[]
            {
            new InversionAguaPotable()
            {
                TransaccionID = 1,
                Monto = 97902376M,
                Concepto = "Inversion en Agua Potable - Etapa 1",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
                LpsAportados = 300,
            },
            new InversionAguaPotable()
            {
                TransaccionID = 2,
                Monto = 79803360,
                Concepto = "Inversion en Agua Potable - Etapa 2",
                FechaDeTransaccion = new DateTime(2012, 1, 1),
                LpsAportados = 224.87,
            },
            new InversionElectricidad()
            {
                TransaccionID = 3,
                Monto = 145173363.08M,
                Concepto = "Inversion en Convenio Dixus - CFE",
                FechaDeTransaccion = new DateTime(2012, 1, 1),
                MvAsAportados = 72.9,
            },
            new InversionVialidades()
            {
                TransaccionID = 4,
                Monto = 336712257.29M,
                Concepto = "Costo de todas las vialidades",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionRedDigital()
            {
                TransaccionID = 5,
                Monto = 1844269.1086376M,
                Concepto = "Costo de toda la Red Digital",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionGasNatural()
            {
                TransaccionID = 6,
                Monto = 10000000,
                Concepto = "Inversion en Gas Natural",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionEstudiosYProyectos()
            {
                TransaccionID = 7,
                Monto = 32907813.3490175M,
                Concepto = "Inversion en Estudios Y Proyectos",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionPostVenta()
            {
                TransaccionID = 8,
                Monto = 18609572M,
                Concepto = "Inversion en Post-venta",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionCostosIndirectosObra()
            {
                TransaccionID = 9,
                Monto = 32907813.3490175M,
                Concepto = "Inversion en Costos Indirectos ",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionObrasEspeciales()
            {
                TransaccionID = 10,
                Monto = 6000000M,
                Concepto = "Inversion en Obras Especiales ",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionMovimientoTierra()
            {
                TransaccionID = 11,
                Monto = 128532680M,
                Concepto = "Inversion en Movimiento de Tierra ",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            },
            new InversionSaneamiento()
            {
                TransaccionID = 12,
                Monto = 117194800M,
                Concepto = "Inversion en Saneamiento - Etapa 1",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
                LpsSaneamientoAportados = 180.23
            },
            new InversionSaneamiento()
            {
                TransaccionID = 13,
                Monto = 105806060.6M,
                Concepto = "Inversion en Saneamiento - Etapa 2",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
                LpsSaneamientoAportados = 151.36
            },
            new InversionVialidades()
            {
                TransaccionID = 14,
                Monto = 67957945.5456679M,
                Concepto = "Ajuste aa costo de vialidades para que quede como el calculo anterior",
                FechaDeTransaccion = new DateTime(2010, 1, 1),
            }
        };


        }

        public TipoDeSuelo[] ObtenerTiposDeSuelo()
        {

            return new TipoDeSuelo[]
            {

                new TipoDeSueloVivienda()
                {
                    TipoDeSueloId = 1,
                    Nombre = "Vivienda Economica",
                    Color = "#ffcc00",
                    HabitantesPorViviendaPromedio = 3.9,
                    ViviendaPorHectareaPromedio = 70,
                    MvaPorHectarea = 0.04044,
                    TuDeReferencia = 1100,
                },
                new TipoDeSueloVivienda()
                {
                    TipoDeSueloId = 2,
                    Nombre = "Vivienda Social",
                    Color = "#b2b266",
                    HabitantesPorViviendaPromedio = 3.9,
                    ViviendaPorHectareaPromedio = 60,
                    MvaPorHectarea = 0.0623,
                    TuDeReferencia = 1100,
                },
                new TipoDeSueloVivienda()
                {
                    TipoDeSueloId = 3,
                    Nombre = "Vivienda Popular",
                    Color = "#ff9900",
                    HabitantesPorViviendaPromedio = 3.9,
                    ViviendaPorHectareaPromedio = 60,
                    MvaPorHectarea = 0.0278,
                    TuDeReferencia = 1100,
                },
                new TipoDeSueloVivienda()
                {
                    TipoDeSueloId = 4,
                    Nombre = "Vivienda Media",
                    Color = "#990000",
                    HabitantesPorViviendaPromedio = 3.9,
                    ViviendaPorHectareaPromedio = 34,
                    MvaPorHectarea = 0.1189,
                    TuDeReferencia = 1200,
                },
                new TipoDeSueloVivienda()
                {
                    TipoDeSueloId = 5,
                    Nombre = "Vivienda Residencial",
                    Color = "#ff99ff",
                    HabitantesPorViviendaPromedio = 3.9,
                    ViviendaPorHectareaPromedio = 17,
                    MvaPorHectarea = 0.0499,
                    TuDeReferencia = 1200,
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 6,
                    Nombre = "Comercial",
                    Color = "#009999",
                    MvaPorHectarea = 0.1087676,
                    LpsPorHectareaParaDemanda = 0.69,
                    PorcentajeParaDemanda = 0.75,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 7,
                    Nombre = "Comercio y Servicios",
                    Color = "#4dffff",
                    MvaPorHectarea = 0.0597,
                    LpsPorHectareaParaDemanda = .69,
                    PorcentajeParaDemanda = .75,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 8,
                    Nombre = "Industrial",
                    Color = "#e67300",
                    MvaPorHectarea = 0.1419,
                    LpsPorHectareaParaDemanda = 0.85,
                    PorcentajeParaDemanda = 0.60,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 9,
                    Nombre = "Parque Alta Tecnología",
                    Color = "#b3b3b3",
                    MvaPorHectarea = 0.1466,
                    LpsPorHectareaParaDemanda = 0.69,
                    PorcentajeParaDemanda = 1,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 10,
                    Nombre = "Servicios Especiales",
                    Color = "#ac39ac",
                    MvaPorHectarea = 0.0668,
                    LpsPorHectareaParaDemanda = 0.75,
                    PorcentajeParaDemanda = 0.75,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 11,
                    Nombre = "Área de Conservación",
                    Color = "#808080",
                    MvaPorHectarea = 0.0357128,
                    LpsPorHectareaParaDemanda = 0.69,
                    PorcentajeParaDemanda = 0.75,
                    TuDeReferencia = 1300
                },
                new TipoDeSueloEmpresarial()
                {
                    TipoDeSueloId = 12,
                    Nombre = "Reserva Estratégica",
                    Color = "#e6e6e6",
                    MvaPorHectarea = 0.0597,
                    LpsPorHectareaParaDemanda = 0.69,
                    PorcentajeParaDemanda = 0.75,
                    TuDeReferencia = 1300
                },
                new TipoDeSuelo()
                {
                    TipoDeSueloId = 13,
                    Nombre = "Equipamiento Urbano",
                    Color = "#33cc33",
                    MvaPorHectarea = 0
                },
                new TipoDeSuelo()
                {
                    TipoDeSueloId = 14,
                    Nombre = "Donaciones",
                    Color = "#9999ff",
                    MvaPorHectarea = 0
                }
            };
        }

        public MyUser[] ObtenerUsuarios()
        {

            return new MyUser[]
            {
                new MyUser(){
                    Id = "d606da6a-fe2e-4ef5-b792-15833b95ddba",
                    Nombre = "Joaquin",
                    Apellido = "Paniagua García de León",
                    Email = "chatopaniagua@gmail.com",
                    Puesto = "Desarrollador de Software",
                    UserName = "Chatopaniagua",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("Paniagua1"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "aa768ce1-60ca-4c47-9018-f8507468000e",
                    Nombre = "Cecilia",
                    Apellido = "García de León Peñuñuri",
                    Email = "cgarcia@e-valorem.com",
                    Puesto = "Directora General",
                    UserName = "CGarcia",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "797d9397-a23c-46fe-9b11-93e17f9fd082",
                    Nombre = "Guillermo",
                    Apellido = "Ulloa",
                    Email = "gulloa@dixus.com.mx",
                    Puesto = "Director técnico",
                    UserName = "Guillermoulloa",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "b52969af-92b9-44b0-8570-e6c13a69d2ba",
                    Nombre = "Fabian",
                    Apellido = "Iriarte",
                    Email = "firiarte@dixus.com.mx",
                    Puesto = "Arquitecto",
                    UserName = "FIriarte",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "92ca11be-82ae-4709-a4c9-db29bda0997e",
                    Nombre = "Marco Antonio",
                    Apellido = "Garcia de León Peñuñuri",
                    Email = "marco.garciadeleon@dixus.com.mx",
                    Puesto = "Director General",
                    UserName = "MGDL",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "95fd0716-f55d-4717-9f68-5c0ddf6623cb",
                    Nombre = "Mirna",
                    Apellido = "Quintanilla",
                    Email = "mquintanilla@dixus.com.mx",
                    Puesto = "Abogada",
                    UserName = "MQuintanilla",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "138b6203-2902-45bc-a7fc-d683a59d23d3",
                    Nombre = "Fernando",
                    Apellido = "García de León Peñuñuri",
                    Email = "fgarcia@e-valorem.com",
                    Puesto = "Director de Promoción",
                    UserName = "FernandoGDL",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                },
                new MyUser() {
                    Id = "2d0afeda-1878-4e22-80e2-e939a37c356f",
                    Nombre = "Raymundo",
                    Apellido = "García de León Peñuñuri",
                    Email = "chatopaniagua@gmail.com",
                    Puesto = "Director General",
                    UserName = "RaymundoGDL",
                    PasswordHash = _usermanager.PasswordHasher.HashPassword("EvaDix2016!"),
                    SecurityStamp = "hola",
                    EmailConfirmed = true
                }
            };

        }

        public MyRole[] ObtenerRoles()
        {

            return new MyRole[]
            {
                new MyRole() { Name = "Administrador" },
                new MyRole() { Name = "Técnico" },
                new MyRole() { Name = "Legal" },
                new MyRole() { Name = "Ventas" },
            };

        }

        public JuntaDeConsejo[] ObtenerJuntas()
        {

            return new JuntaDeConsejo[]
            {
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 1,
                    Fecha = new DateTime(2016,05,20),
                    Titulo = "Junta Presentacion SIDIX",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 2,
                    Fecha = DateTime.Now,
                    Titulo = "Revision de avances sistema SIDIX",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 3,
                    Fecha = new DateTime(2016,2,10),
                    Titulo = "Consejo DIXUS",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 4,
                    Fecha = new DateTime(2016,4,1),
                    Titulo = "Consejo VINTEL",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 5,
                    Fecha = new DateTime(2015,12,24),
                    Titulo = "Reunion de Navidad",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 6,
                    Fecha = new DateTime(2015,10,6),
                    Titulo = "Consejo Evalorem",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 7,
                    Fecha = new DateTime(2016,12,24),
                    Titulo = "Junta Operativa VINTEL",
                    UsuariosPresentes = new List<MyUser>(),
                    Observaciones = "También estubo la Mony Hernandez y Kako",
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 8,
                    Fecha = new DateTime(2016,1,6),
                    Titulo = "Junta Operativa Evalorem",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },
                new JuntaDeConsejo()  {
                    JuntaDeConsejoId = 9,
                    Fecha = new DateTime(2016,3,21),
                    Titulo = "Consejo Primaveral DIXUS",
                    UsuariosPresentes = new List<MyUser>(),
                    //UsuarioCreadorId = "d606da6a-fe2e-4ef5-b792-15833b95ddba"
                },

            };

        }

        public Vialidad[] ObtenerVialidades()
        {
            return new Vialidad[]
            {
                new Vialidad()
                {
                    VialidadId = 1,
                    Nombre = "Vialidad-1",
                    Tramo = "F2",
                    FechaCreada = DateTime.Now,
                    Longitud = 1000,
                    MetrosCuadrados = 2000,
                    NumeroDeCarriles = 2,
                    Geometria = DbGeometry.FromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))", 32612)
                }
            };
        }
    }
}
