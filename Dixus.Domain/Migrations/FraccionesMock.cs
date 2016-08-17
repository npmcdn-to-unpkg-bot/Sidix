//using Dixus.Entidades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dixus.Domain.Migrations
//{
//    public static partial class FraccionesPlanMaestroMock
//    {
//        public static Fraccion[] ObtenerFracciones()
//        {
//            Fraccion[] Fracciones = new Fraccion[]
//            {
//                new FraccionViviendaEconomica(){
//                    FraccionId = 1,
//                    Nombre = "VE-1",
//                    MetrosCuadrados = 180586.529,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 2,
//                    Nombre = "VE-2",
//                    MetrosCuadrados = 164329.157,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 3,
//                    Nombre = "VE-3",
//                    MetrosCuadrados = 122671.968,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 4,
//                    Nombre = "VE-4",
//                    MetrosCuadrados = 253019.989,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 5,
//                    Nombre = "VE-4a",
//                    MetrosCuadrados = 2229.302,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 6,
//                    Nombre = "VE-5a",
//                    MetrosCuadrados = 78244.718,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 7,
//                    Nombre = "VE-5b",
//                    MetrosCuadrados = 78244.717,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 8,
//                    Nombre = "VE-6a",
//                    MetrosCuadrados = 60000,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 9,
//                    Nombre = "VE-6b",
//                    MetrosCuadrados = 114701.547,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 10,
//                    Nombre = "KE-01",
//                    MetrosCuadrados = 1626.791,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 11,
//                    Nombre = "KE-02",
//                    MetrosCuadrados = 1489.557,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 12,
//                    Nombre = "VE-7a",
//                    MetrosCuadrados = 72438.42,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 13,
//                    Nombre = "VE-7b",
//                    MetrosCuadrados = 72438.418,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 14,
//                    Nombre = "VE-8",
//                    MetrosCuadrados = 198888.76,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 15,
//                    Nombre = "VE-9",
//                    MetrosCuadrados = 176581.584,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 16,
//                    Nombre = "VE-10a",
//                    MetrosCuadrados = 30000,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 17,
//                    Nombre = "VE-10b",
//                    MetrosCuadrados = 100000.035,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 18,
//                    Nombre = "VE-11",
//                    MetrosCuadrados = 107218.989,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 19,
//                    Nombre = "VE-12ar",
//                    MetrosCuadrados = 20000,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 20,
//                    Nombre = "VE-12b",
//                    MetrosCuadrados = 38092.798,
//                },

//                new FraccionViviendaEconomica(){
//                    FraccionId = 21,
//                    Nombre = "VE-12c",
//                    MetrosCuadrados = 11907.202,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 22,
//                    Nombre = "VS-1",
//                    MetrosCuadrados = 100542.813,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 23,
//                    Nombre = "VS-2",
//                    MetrosCuadrados = 25765.813,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 24,
//                    Nombre = "VS-3",
//                    MetrosCuadrados = 49544.072,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 25,
//                    Nombre = "VS-4",
//                    MetrosCuadrados = 38887.157,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 26,
//                    Nombre = "VS-4a",
//                    MetrosCuadrados = 13564.232,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 27,
//                    Nombre = "VS-5",
//                    MetrosCuadrados = 129403.827,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 28,
//                    Nombre = "VS-6",
//                    MetrosCuadrados = 78496.558,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 29,
//                    Nombre = "VS-7",
//                    MetrosCuadrados = 85161.001,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 30,
//                    Nombre = "VS-8",
//                    MetrosCuadrados = 58409.38,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 31,
//                    Nombre = "VS-9",
//                    MetrosCuadrados = 58379.826,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 32,
//                    Nombre = "VS-10",
//                    MetrosCuadrados = 11659.629,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 33,
//                    Nombre = "VS-11",
//                    MetrosCuadrados = 37450.773,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 34,
//                    Nombre = "VS-12a",
//                    MetrosCuadrados = 60000,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 35,
//                    Nombre = "VS-12b",
//                    MetrosCuadrados = 60000,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 36,
//                    Nombre = "VS-12c",
//                    MetrosCuadrados = 40000,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 37,
//                    Nombre = "VS-13A",
//                    MetrosCuadrados = 103947.379,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 38,
//                    Nombre = "VS-13B",
//                    MetrosCuadrados = 60738.934,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 39,
//                    Nombre = "VS-14",
//                    MetrosCuadrados = 82482.054,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 40,
//                    Nombre = "VS-15",
//                    MetrosCuadrados = 4841.818,
//                },

//                new FraccionViviendaSocial(){
//                    FraccionId = 41,
//                    Nombre = "VS-16",
//                    MetrosCuadrados = 21042.143,
//                },

//                new FraccionIN(){
//                    FraccionId = 42,
//                    Nombre = "I-15",
//                    MetrosCuadrados = 101416.796,
//                },

//                new FraccionIN(){
//                    FraccionId = 43,
//                    Nombre = "I-16",
//                    MetrosCuadrados = 100168.542,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 44,
//                    Nombre = "VP-1",
//                    MetrosCuadrados = 11897.34,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 45,
//                    Nombre = "VP-2",
//                    MetrosCuadrados = 9741.88,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 46,
//                    Nombre = "VP-3",
//                    MetrosCuadrados = 7679.91,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 47,
//                    Nombre = "VP-4",
//                    MetrosCuadrados = 23382.32,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 48,
//                    Nombre = "VP-5",
//                    MetrosCuadrados = 13447.89,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 49,
//                    Nombre = "VP-6",
//                    MetrosCuadrados = 17929.11,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 50,
//                    Nombre = "VP-7",
//                    MetrosCuadrados = 16332.15,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 51,
//                    Nombre = "VP-8a1",
//                    MetrosCuadrados = 79099.18,
//                },

//                new FraccionViviendaPopular(){
//                    FraccionId = 52,
//                    Nombre = "VP-8a2",
//                    MetrosCuadrados = 9297.526,
//                },

//                new FraccionViviendaMedia(){
//                    FraccionId = 53,
//                    Nombre = "VM-1",
//                    MetrosCuadrados = 185395.62,
//                },

//                new FraccionViviendaMedia(){
//                    FraccionId = 54,
//                    Nombre = "VM-2",
//                    MetrosCuadrados = 185395.62,
//                },

//                new FraccionViviendaResidencial(){
//                    FraccionId = 55,
//                    Nombre = "VR-1",
//                    MetrosCuadrados = 124188.12,
//                },

//                new FraccionViviendaResidencial(){
//                    FraccionId = 56,
//                    Nombre = "VR-2",
//                    MetrosCuadrados = 124188.12,
//                },

//                new FraccionViviendaResidencial(){
//                    FraccionId = 57,
//                    Nombre = "VR-3",
//                    MetrosCuadrados = 124188.12,
//                },

//                new FraccionViviendaResidencial(){
//                    FraccionId = 58,
//                    Nombre = "VR-4",
//                    MetrosCuadrados = 124188.12,
//                },

//                new FraccionCOM(){
//                    FraccionId = 59,
//                    Nombre = "COM-0",
//                    MetrosCuadrados = 823.108,
//                },

//                new FraccionCOM(){
//                    FraccionId = 60,
//                    Nombre = "COM-1a",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 61,
//                    Nombre = "COM-1b",
//                    MetrosCuadrados = 865,
//                },

//                new FraccionCOM(){
//                    FraccionId = 62,
//                    Nombre = "COM-1c",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 63,
//                    Nombre = "COM-1d",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 64,
//                    Nombre = "COM-1e",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 65,
//                    Nombre = "COM-1f",
//                    MetrosCuadrados = 1071.538,
//                },

//                new FraccionCOM(){
//                    FraccionId = 66,
//                    Nombre = "COM-1g",
//                    MetrosCuadrados = 1017.709,
//                },

//                new FraccionCOM(){
//                    FraccionId = 67,
//                    Nombre = "COM-2a",
//                    MetrosCuadrados = 5218.492,
//                },

//                new FraccionCOM(){
//                    FraccionId = 68,
//                    Nombre = "COM-2b",
//                    MetrosCuadrados = 2818.061,
//                },

//                new FraccionCOM(){
//                    FraccionId = 69,
//                    Nombre = "COM-3a",
//                    MetrosCuadrados = 1000.001,
//                },

//                new FraccionCOM(){
//                    FraccionId = 70,
//                    Nombre = "COM-3b",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 71,
//                    Nombre = "COM-3b",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 72,
//                    Nombre = "COM-3x",
//                    MetrosCuadrados = 7776.861,
//                },

//                new FraccionCOM(){
//                    FraccionId = 73,
//                    Nombre = "COM-3y",
//                    MetrosCuadrados = 3929.41,
//                },

//                new FraccionCOM(){
//                    FraccionId = 74,
//                    Nombre = "COM-4",
//                    MetrosCuadrados = 7957.643,
//                },

//                new FraccionCOM(){
//                    FraccionId = 75,
//                    Nombre = "COM-5a",
//                    MetrosCuadrados = 10002.681,
//                },

//                new FraccionCOM(){
//                    FraccionId = 76,
//                    Nombre = "COM-5b",
//                    MetrosCuadrados = 2149.449,
//                },

//                new FraccionCOM(){
//                    FraccionId = 77,
//                    Nombre = "COM-6a",
//                    MetrosCuadrados = 5000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 78,
//                    Nombre = "COM-6b",
//                    MetrosCuadrados = 999.999,
//                },

//                new FraccionCOM(){
//                    FraccionId = 79,
//                    Nombre = "COM-6c",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 80,
//                    Nombre = "COM-6d",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 81,
//                    Nombre = "COM-6e",
//                    MetrosCuadrados = 1409.47,
//                },

//                new FraccionCOM(){
//                    FraccionId = 82,
//                    Nombre = "COM-6f",
//                    MetrosCuadrados = 1596.388,
//                },

//                new FraccionCOM(){
//                    FraccionId = 83,
//                    Nombre = "COM-6g",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 84,
//                    Nombre = "COM-6h",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 85,
//                    Nombre = "COM-6i",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 86,
//                    Nombre = "COM-6j",
//                    MetrosCuadrados = 1000.003,
//                },

//                new FraccionCOM(){
//                    FraccionId = 87,
//                    Nombre = "COM-6k",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 88,
//                    Nombre = "COM-6l",
//                    MetrosCuadrados = 1769.633,
//                },

//                new FraccionCOM(){
//                    FraccionId = 89,
//                    Nombre = "COM-7",
//                    MetrosCuadrados = 2104.011,
//                },

//                new FraccionCOM(){
//                    FraccionId = 90,
//                    Nombre = "COM-8a",
//                    MetrosCuadrados = 1000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 91,
//                    Nombre = "COM-8b",
//                    MetrosCuadrados = 2015.06,
//                },

//                new FraccionCOM(){
//                    FraccionId = 92,
//                    Nombre = "COM-9",
//                    MetrosCuadrados = 5671.296,
//                },

//                new FraccionCOM(){
//                    FraccionId = 93,
//                    Nombre = "COM-10",
//                    MetrosCuadrados = 1741.587,
//                },

//                new FraccionCOM(){
//                    FraccionId = 94,
//                    Nombre = "COM-11",
//                    MetrosCuadrados = 6892.584,
//                },

//                new FraccionCOM(){
//                    FraccionId = 95,
//                    Nombre = "COM-12",
//                    MetrosCuadrados = 10000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 96,
//                    Nombre = "COM-13",
//                    MetrosCuadrados = 10613.887,
//                },

//                new FraccionCOM(){
//                    FraccionId = 97,
//                    Nombre = "COM-14",
//                    MetrosCuadrados = 19098.438,
//                },

//                new FraccionCOM(){
//                    FraccionId = 98,
//                    Nombre = "COM-15",
//                    MetrosCuadrados = 10000.002,
//                },

//                new FraccionCOM(){
//                    FraccionId = 99,
//                    Nombre = "COM-16",
//                    MetrosCuadrados = 21118.611,
//                },

//                new FraccionCOM(){
//                    FraccionId = 100,
//                    Nombre = "COM-17",
//                    MetrosCuadrados = 2500,
//                },

//                new FraccionCOM(){
//                    FraccionId = 101,
//                    Nombre = "COM-18",
//                    MetrosCuadrados = 2500,
//                },

//                new FraccionCOM(){
//                    FraccionId = 102,
//                    Nombre = "COM-19",
//                    MetrosCuadrados = 5000,
//                },

//                new FraccionCOM(){
//                    FraccionId = 103,
//                    Nombre = "COM-20",
//                    MetrosCuadrados = 117413.65,
//                },

//                new FraccionCOM(){
//                    FraccionId = 104,
//                    Nombre = "COM-21",
//                    MetrosCuadrados = 14686.724,
//                },

//                new FraccionCOM(){
//                    FraccionId = 105,
//                    Nombre = "COM-22",
//                    MetrosCuadrados = 24600.023,
//                },

//                new FraccionCOM(){
//                    FraccionId = 106,
//                    Nombre = "COM-23",
//                    MetrosCuadrados = 11688.341,
//                },

//                new FraccionCOM(){
//                    FraccionId = 107,
//                    Nombre = "COM-24",
//                    MetrosCuadrados = 11369.182,
//                },

//                new FraccionCOM(){
//                    FraccionId = 108,
//                    Nombre = "COM-25",
//                    MetrosCuadrados = 120556.631,
//                },

//                new FraccionCOM(){
//                    FraccionId = 109,
//                    Nombre = "COM-26",
//                    MetrosCuadrados = 24432.693,
//                },

//                new FraccionCOM(){
//                    FraccionId = 110,
//                    Nombre = "COM-27",
//                    MetrosCuadrados = 4450.532,
//                },

//                new FraccionCOM(){
//                    FraccionId = 111,
//                    Nombre = "COM-28",
//                    MetrosCuadrados = 11321.588,
//                },

//                new FraccionCOM(){
//                    FraccionId = 112,
//                    Nombre = "COM-29",
//                    MetrosCuadrados = 20969.804,
//                },

//                new FraccionCOM(){
//                    FraccionId = 113,
//                    Nombre = "COM-30",
//                    MetrosCuadrados = 12634.993,
//                },

//                new FraccionCOM(){
//                    FraccionId = 114,
//                    Nombre = "COM-31",
//                    MetrosCuadrados = 3450.814,
//                },

//                new FraccionCOM(){
//                    FraccionId = 115,
//                    Nombre = "COM-32",
//                    MetrosCuadrados = 52592.613,
//                },

//                new FraccionCOM(){
//                    FraccionId = 116,
//                    Nombre = "COM-33",
//                    MetrosCuadrados = 28029.201,
//                },

//                new FraccionCOM(){
//                    FraccionId = 117,
//                    Nombre = "COM-34",
//                    MetrosCuadrados = 81283.68,
//                },

//                new FraccionCOM(){
//                    FraccionId = 118,
//                    Nombre = "COM-35",
//                    MetrosCuadrados = 4346.576,
//                },

//                new FraccionCOM(){
//                    FraccionId = 119,
//                    Nombre = "COM-36",
//                    MetrosCuadrados = 4500,
//                },

//                new FraccionCOM(){
//                    FraccionId = 120,
//                    Nombre = "COM-37",
//                    MetrosCuadrados = 4813.022,
//                },

//                new FraccionCOM(){
//                    FraccionId = 121,
//                    Nombre = "COM-38",
//                    MetrosCuadrados = 59202.048,
//                },

//                new FraccionCS(){
//                    FraccionId = 122,
//                    Nombre = "CS-1a",
//                    MetrosCuadrados = 41832.013,
//                },

//                new FraccionCS(){
//                    FraccionId = 123,
//                    Nombre = "CS-1b",
//                    MetrosCuadrados = 42078.633,
//                },

//                new FraccionCS(){
//                    FraccionId = 124,
//                    Nombre = "CS-2",
//                    MetrosCuadrados = 6256.268,
//                },

//                new FraccionCS(){
//                    FraccionId = 125,
//                    Nombre = "CS-3",
//                    MetrosCuadrados = 18056.305,
//                },

//                new FraccionCS(){
//                    FraccionId = 126,
//                    Nombre = "CS-4",
//                    MetrosCuadrados = 12919.146,
//                },

//                new FraccionCS(){
//                    FraccionId = 127,
//                    Nombre = "CS5-1",
//                    MetrosCuadrados = 4174.766,
//                },

//                new FraccionCS(){
//                    FraccionId = 128,
//                    Nombre = "CS5-2",
//                    MetrosCuadrados = 300.133,
//                },

//                new FraccionCS(){
//                    FraccionId = 129,
//                    Nombre = "CS6-1",
//                    MetrosCuadrados = 777.569,
//                },

//                new FraccionCS(){
//                    FraccionId = 130,
//                    Nombre = "CS6-2",
//                    MetrosCuadrados = 940.858,
//                },

//                new FraccionCS(){
//                    FraccionId = 131,
//                    Nombre = "CS6-3",
//                    MetrosCuadrados = 1683.618,
//                },

//                new FraccionCS(){
//                    FraccionId = 132,
//                    Nombre = "CS6-4",
//                    MetrosCuadrados = 900,
//                },

//                new FraccionCS(){
//                    FraccionId = 133,
//                    Nombre = "CS6-7",
//                    MetrosCuadrados = 6993.54,
//                },

//                new FraccionCS(){
//                    FraccionId = 134,
//                    Nombre = "CS-9",
//                    MetrosCuadrados = 3215.42,
//                },

//                new FraccionCS(){
//                    FraccionId = 135,
//                    Nombre = "CS-10",
//                    MetrosCuadrados = 11259.886,
//                },

//                new FraccionCS(){
//                    FraccionId = 136,
//                    Nombre = "CS-11",
//                    MetrosCuadrados = 4869.01,
//                },

//                new FraccionCS(){
//                    FraccionId = 137,
//                    Nombre = "CS-12",
//                    MetrosCuadrados = 5803.529,
//                },

//                new FraccionCS(){
//                    FraccionId = 138,
//                    Nombre = "CS-13A",
//                    MetrosCuadrados = 10890.394,
//                },

//                new FraccionCS(){
//                    FraccionId = 139,
//                    Nombre = "CS-13B",
//                    MetrosCuadrados = 9157.468,
//                },

//                new FraccionCS(){
//                    FraccionId = 140,
//                    Nombre = "CS-13C",
//                    MetrosCuadrados = 9976.484,
//                },

//                new FraccionCS(){
//                    FraccionId = 141,
//                    Nombre = "CS-13D",
//                    MetrosCuadrados = 17157.524,
//                },

//                new FraccionCS(){
//                    FraccionId = 142,
//                    Nombre = "CS-13E",
//                    MetrosCuadrados = 20823.847,
//                },

//                new FraccionCS(){
//                    FraccionId = 143,
//                    Nombre = "CS-14",
//                    MetrosCuadrados = 29488.237,
//                },

//                new FraccionCS(){
//                    FraccionId = 144,
//                    Nombre = "CS-15",
//                    MetrosCuadrados = 18651.518,
//                },

//                new FraccionCS(){
//                    FraccionId = 145,
//                    Nombre = "CS-16",
//                    MetrosCuadrados = 13078.084,
//                },

//                new FraccionCS(){
//                    FraccionId = 146,
//                    Nombre = "CS-17",
//                    MetrosCuadrados = 24414.848,
//                },

//                new FraccionCS(){
//                    FraccionId = 147,
//                    Nombre = "CS-18",
//                    MetrosCuadrados = 29643.414,
//                },

//                new FraccionCS(){
//                    FraccionId = 148,
//                    Nombre = "CS-19A",
//                    MetrosCuadrados = 6750.473,
//                },

//                new FraccionCS(){
//                    FraccionId = 149,
//                    Nombre = "CS-19B",
//                    MetrosCuadrados = 15252.785,
//                },

//                new FraccionCS(){
//                    FraccionId = 150,
//                    Nombre = "CS-20",
//                    MetrosCuadrados = 22426.601,
//                },

//                new FraccionCS(){
//                    FraccionId = 151,
//                    Nombre = "CS-21",
//                    MetrosCuadrados = 9722.729,
//                },

//                new FraccionCS(){
//                    FraccionId = 152,
//                    Nombre = "CS-22",
//                    MetrosCuadrados = 9888.027,
//                },

//                new FraccionCS(){
//                    FraccionId = 153,
//                    Nombre = "CS-23",
//                    MetrosCuadrados = 9546.09,
//                },

//                new FraccionCS(){
//                    FraccionId = 154,
//                    Nombre = "CS-24",
//                    MetrosCuadrados = 9902.874,
//                },

//                new FraccionCS(){
//                    FraccionId = 155,
//                    Nombre = "CS-25",
//                    MetrosCuadrados = 23665.195,
//                },

//                new FraccionCS(){
//                    FraccionId = 156,
//                    Nombre = "CS-26",
//                    MetrosCuadrados = 16538.01,
//                },

//                new FraccionCS(){
//                    FraccionId = 157,
//                    Nombre = "CS-27",
//                    MetrosCuadrados = 69351.532,
//                },

//                new FraccionCS(){
//                    FraccionId = 158,
//                    Nombre = "CS-28",
//                    MetrosCuadrados = 63419.768,
//                },

//                new FraccionCS(){
//                    FraccionId = 159,
//                    Nombre = "CS-29",
//                    MetrosCuadrados = 17765.756,
//                },

//                new FraccionCS(){
//                    FraccionId = 160,
//                    Nombre = "CS-30",
//                    MetrosCuadrados = 52104.737,
//                },

//                new FraccionCS(){
//                    FraccionId = 161,
//                    Nombre = "CS-31",
//                    MetrosCuadrados = 16959.319,
//                },

//                new FraccionCS(){
//                    FraccionId = 162,
//                    Nombre = "CS-32",
//                    MetrosCuadrados = 9999.998,
//                },

//                new FraccionCS(){
//                    FraccionId = 163,
//                    Nombre = "CS-33",
//                    MetrosCuadrados = 36256.401,
//                },

//                new FraccionCS(){
//                    FraccionId = 164,
//                    Nombre = "CS-34",
//                    MetrosCuadrados = 21529.693,
//                },

//                new FraccionCS(){
//                    FraccionId = 165,
//                    Nombre = "CS-35",
//                    MetrosCuadrados = 11150.995,
//                },

//                new FraccionCS(){
//                    FraccionId = 166,
//                    Nombre = "CS-36",
//                    MetrosCuadrados = 13321.72,
//                },

//                new FraccionCS(){
//                    FraccionId = 167,
//                    Nombre = "CS-37",
//                    MetrosCuadrados = 34623.668,
//                },

//                new FraccionCS(){
//                    FraccionId = 168,
//                    Nombre = "CS-38",
//                    MetrosCuadrados = 23785.998,
//                },

//                new FraccionCS(){
//                    FraccionId = 169,
//                    Nombre = "CS-39",
//                    MetrosCuadrados = 9022.618,
//                },

//                new FraccionCS(){
//                    FraccionId = 170,
//                    Nombre = "CS-40",
//                    MetrosCuadrados = 7020.699,
//                },

//                new FraccionCS(){
//                    FraccionId = 171,
//                    Nombre = "CS-41",
//                    MetrosCuadrados = 8259.506,
//                },

//                new FraccionCS(){
//                    FraccionId = 172,
//                    Nombre = "CS-42a",
//                    MetrosCuadrados = 2498.85,
//                },

//                new FraccionCS(){
//                    FraccionId = 173,
//                    Nombre = "CS-42b",
//                    MetrosCuadrados = 2500,
//                },

//                new FraccionCS(){
//                    FraccionId = 174,
//                    Nombre = "CS-43",
//                    MetrosCuadrados = 8816.611,
//                },

//                new FraccionCS(){
//                    FraccionId = 175,
//                    Nombre = "CS-44",
//                    MetrosCuadrados = 11563.862,
//                },

//                new FraccionCS(){
//                    FraccionId = 176,
//                    Nombre = "CS-45",
//                    MetrosCuadrados = 10010.374,
//                },

//                new FraccionCS(){
//                    FraccionId = 177,
//                    Nombre = "CS-46",
//                    MetrosCuadrados = 14624.148,
//                },

//                new FraccionCS(){
//                    FraccionId = 178,
//                    Nombre = "CS-47",
//                    MetrosCuadrados = 129780.333,
//                },

//                new FraccionCS(){
//                    FraccionId = 179,
//                    Nombre = "CS-48",
//                    MetrosCuadrados = 24625.06,
//                },

//                new FraccionCS(){
//                    FraccionId = 180,
//                    Nombre = "CS-49",
//                    MetrosCuadrados = 27046.918,
//                },

//                new FraccionIN(){
//                    FraccionId = 181,
//                    Nombre = "I-1",
//                    MetrosCuadrados = 165791.067,
//                },

//                new FraccionIN(){
//                    FraccionId = 182,
//                    Nombre = "I-2",
//                    MetrosCuadrados = 70268.031,
//                },

//                new FraccionIN(){
//                    FraccionId = 183,
//                    Nombre = "I-3",
//                    MetrosCuadrados = 23658.281,
//                },

//                new FraccionIN(){
//                    FraccionId = 184,
//                    Nombre = "I-4",
//                    MetrosCuadrados = 122783.44,
//                },

//                new FraccionIN(){
//                    FraccionId = 185,
//                    Nombre = "I-5",
//                    MetrosCuadrados = 83406.319,
//                },

//                new FraccionIN(){
//                    FraccionId = 186,
//                    Nombre = "I-6",
//                    MetrosCuadrados = 34945.906,
//                },

//                new FraccionIN(){
//                    FraccionId = 187,
//                    Nombre = "I-7",
//                    MetrosCuadrados = 100713.502,
//                },

//                new FraccionIN(){
//                    FraccionId = 188,
//                    Nombre = "I-8",
//                    MetrosCuadrados = 23772.535,
//                },

//                new FraccionIN(){
//                    FraccionId = 189,
//                    Nombre = "I-9",
//                    MetrosCuadrados = 53345.184,
//                },

//                new FraccionIN(){
//                    FraccionId = 190,
//                    Nombre = "I-10",
//                    MetrosCuadrados = 69846.493,
//                },

//                new FraccionIN(){
//                    FraccionId = 191,
//                    Nombre = "I-11",
//                    MetrosCuadrados = 51841.609,
//                },

//                new FraccionIN(){
//                    FraccionId = 192,
//                    Nombre = "I-12",
//                    MetrosCuadrados = 45349.974,
//                },

//                new FraccionIN(){
//                    FraccionId = 193,
//                    Nombre = "I-13",
//                    MetrosCuadrados = 53694.095,
//                },

//                new FraccionIN(){
//                    FraccionId = 194,
//                    Nombre = "I-14",
//                    MetrosCuadrados = 116661.355,
//                },

//                new FraccionIN(){
//                    FraccionId = 195,
//                    Nombre = "I-17",
//                    MetrosCuadrados = 63375.578,
//                },

//                new FraccionIN(){
//                    FraccionId = 196,
//                    Nombre = "I-18",
//                    MetrosCuadrados = 66116.978,
//                },

//                new FraccionIN(){
//                    FraccionId = 197,
//                    Nombre = "I-19",
//                    MetrosCuadrados = 66863.16,
//                },

//                new FraccionIN(){
//                    FraccionId = 198,
//                    Nombre = "I-20",
//                    MetrosCuadrados = 61799.793,
//                },

//                new FraccionIN(){
//                    FraccionId = 199,
//                    Nombre = "I-21",
//                    MetrosCuadrados = 56900.874,
//                },

//                new FraccionPAT(){
//                    FraccionId = 200,
//                    Nombre = "PAT-1",
//                    MetrosCuadrados = 126076.17,
//                },

//                new FraccionPAT(){
//                    FraccionId = 201,
//                    Nombre = "PAT-2",
//                    MetrosCuadrados = 191736.79,
//                },

//                new FraccionSE(){
//                    FraccionId = 202,
//                    Nombre = "SE-1",
//                    MetrosCuadrados = 159709.72,
//                },

//                new FraccionSE(){
//                    FraccionId = 203,
//                    Nombre = "SE-2",
//                    MetrosCuadrados = 56254.66,
//                },

//                new FraccionEU(){
//                    FraccionId = 204,
//                    Nombre = "EQ-1",
//                    MetrosCuadrados = 10117.309,
//                },

//                new FraccionEU(){
//                    FraccionId = 205,
//                    Nombre = "EQ-2",
//                    MetrosCuadrados = 44999.897,
//                },

//                new FraccionEU(){
//                    FraccionId = 206,
//                    Nombre = "EQ-3",
//                    MetrosCuadrados = 9881.476,
//                },

//                new FraccionEU(){
//                    FraccionId = 207,
//                    Nombre = "EQ-4",
//                    MetrosCuadrados = 10000.632,
//                },

//                new FraccionEU(){
//                    FraccionId = 208,
//                    Nombre = "EQ-5",
//                    MetrosCuadrados = 16588.843,
//                },

//                new FraccionEU(){
//                    FraccionId = 209,
//                    Nombre = "EQ-6",
//                    MetrosCuadrados = 14979.811,
//                },

//                new FraccionEU(){
//                    FraccionId = 210,
//                    Nombre = "EQ-7",
//                    MetrosCuadrados = 35780.684,
//                },

//                new FraccionEU(){
//                    FraccionId = 211,
//                    Nombre = "EQ-8",
//                    MetrosCuadrados = 12750.013,
//                },

//                new FraccionEU(){
//                    FraccionId = 212,
//                    Nombre = "EQ-9",
//                    MetrosCuadrados = 220447.217,
//                },

//                new FraccionEU(){
//                    FraccionId = 213,
//                    Nombre = "EQ-10",
//                    MetrosCuadrados = 15480.277,
//                },

//                new FraccionEU(){
//                    FraccionId = 214,
//                    Nombre = "EQ-11",
//                    MetrosCuadrados = 30000,
//                },

//                new FraccionEU(){
//                    FraccionId = 215,
//                    Nombre = "EQ-12",
//                    MetrosCuadrados = 7633.314,
//                },

//                new FraccionAC(){
//                    FraccionId = 216,
//                    Nombre = "AC-1",
//                    MetrosCuadrados = 42215.774,
//                },

//                new FraccionAC(){
//                    FraccionId = 217,
//                    Nombre = "AC-2",
//                    MetrosCuadrados = 62892.151,
//                },

//                new FraccionAC(){
//                    FraccionId = 218,
//                    Nombre = "AC-3",
//                    MetrosCuadrados = 33448.62,
//                },

//                new FraccionAC(){
//                    FraccionId = 219,
//                    Nombre = "AC-4",
//                    MetrosCuadrados = 5763.229,
//                },

//                new FraccionAC(){
//                    FraccionId = 220,
//                    Nombre = "AC-5",
//                    MetrosCuadrados = 12582.192,
//                },

//                new FraccionAC(){
//                    FraccionId = 221,
//                    Nombre = "AC-6",
//                    MetrosCuadrados = 31448.464,
//                },

//                new FraccionAC(){
//                    FraccionId = 222,
//                    Nombre = "AC-7",
//                    MetrosCuadrados = 8434.686,
//                },

//                new FraccionAC(){
//                    FraccionId = 223,
//                    Nombre = "AC-8",
//                    MetrosCuadrados = 43903.327,
//                },

//                new FraccionAC(){
//                    FraccionId = 224,
//                    Nombre = "AC-9",
//                    MetrosCuadrados = 19581.421,
//                },

//                new FraccionAC(){
//                    FraccionId = 225,
//                    Nombre = "AC-10",
//                    MetrosCuadrados = 45065.425,
//                },

//                new FraccionAC(){
//                    FraccionId = 226,
//                    Nombre = "AC-11",
//                    MetrosCuadrados = 40356.64,
//                },

//                new FraccionAC(){
//                    FraccionId = 227,
//                    Nombre = "AC-12",
//                    MetrosCuadrados = 19893.598,
//                },

//                new FraccionAC(){
//                    FraccionId = 228,
//                    Nombre = "AC-13",
//                    MetrosCuadrados = 80774.579,
//                },

//                new FraccionAC(){
//                    FraccionId = 229,
//                    Nombre = "AC-14",
//                    MetrosCuadrados = 18522.434,
//                },

//                new FraccionRE(){
//                    FraccionId = 230,
//                    Nombre = "RE-1",
//                    MetrosCuadrados = 83623.911,
//                },

//                new FraccionRE(){
//                    FraccionId = 231,
//                    Nombre = "RE-2",
//                    MetrosCuadrados = 135009.457,
//                },

//                new FraccionRE(){
//                    FraccionId = 232,
//                    Nombre = "RE-3",
//                    MetrosCuadrados = 143659.578,
//                },

//                new FraccionRE(){
//                    FraccionId = 233,
//                    Nombre = "RE-4",
//                    MetrosCuadrados = 72004.221,
//                },

//                new FraccionRE(){
//                    FraccionId = 234,
//                    Nombre = "RE-5",
//                    MetrosCuadrados = 24676.474,
//                },

//                new FraccionRE(){
//                    FraccionId = 235,
//                    Nombre = "RE-6",
//                    MetrosCuadrados = 33471.737,
//                },

//                new FraccionRE(){
//                    FraccionId = 236,
//                    Nombre = "RE-7",
//                    MetrosCuadrados = 23689.898,
//                },

//                new FraccionRE(){
//                    FraccionId = 237,
//                    Nombre = "RE-8",
//                    MetrosCuadrados = 37822.563,
//                },

//                new FraccionRE(){
//                    FraccionId = 238,
//                    Nombre = "RE-9",
//                    MetrosCuadrados = 5127.935,
//                },

//                new FraccionRE(){
//                    FraccionId = 239,
//                    Nombre = "RE-10",
//                    MetrosCuadrados = 2630.32,
//                },

//                new FraccionRE(){
//                    FraccionId = 240,
//                    Nombre = "RE-11",
//                    MetrosCuadrados = 590.849,
//                },

//                new FraccionDON(){
//                    FraccionId = 241,
//                    Nombre = "DON-1",
//                    MetrosCuadrados = 7363.435,
//                },

//                new FraccionDON(){
//                    FraccionId = 242,
//                    Nombre = "DON-2",
//                    MetrosCuadrados = 511.606,
//                },

//                new FraccionDON(){
//                    FraccionId = 243,
//                    Nombre = "DON-3",
//                    MetrosCuadrados = 11601.05,
//                },

//                new FraccionDON(){
//                    FraccionId = 244,
//                    Nombre = "DON-4",
//                    MetrosCuadrados = 521.371,
//                },

//                new FraccionDON(){
//                    FraccionId = 245,
//                    Nombre = "DON-5",
//                    MetrosCuadrados = 586.311,
//                },

//                new FraccionDON(){
//                    FraccionId = 246,
//                    Nombre = "DON-6",
//                    MetrosCuadrados = 317.414,
//                },

//                new FraccionDON(){
//                    FraccionId = 247,
//                    Nombre = "DON-7",
//                    MetrosCuadrados = 1064.918,
//                },

//                new FraccionDON(){
//                    FraccionId = 248,
//                    Nombre = "DON-8",
//                    MetrosCuadrados = 389.713,
//                },

//                new FraccionDON(){
//                    FraccionId = 249,
//                    Nombre = "DON-9",
//                    MetrosCuadrados = 2398.824,
//                },

//                new FraccionDON(){
//                    FraccionId = 250,
//                    Nombre = "DON-10",
//                    MetrosCuadrados = 2996.748,
//                },

//                new FraccionDON(){
//                    FraccionId = 251,
//                    Nombre = "DON-11",
//                    MetrosCuadrados = 480.004,
//                },

//                new FraccionDON(){
//                    FraccionId = 252,
//                    Nombre = "DON-12",
//                    MetrosCuadrados = 6963.945,
//                },

//                new FraccionDON(){
//                    FraccionId = 253,
//                    Nombre = "DON-13",
//                    MetrosCuadrados = 2806.429,
//                },

//                new FraccionVIAL(){
//                    FraccionId = 254,
//                    Nombre = "VIAL-1",
//                    MetrosCuadrados = 829906.522,
//                },

//            };

//            return Fracciones;

//        }

//        // Esta es la informacion antes de actualizarse (cargada alrededor de Marzo 2016)
//        //public static List<Fraccion> GetFracciones()
//        //{
//        //    List<Fraccion> fracciones = new List<Fraccion>()
//        //    {
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-1",
//        //            MetrosCuadrados =  180586.529,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-2",
//        //            MetrosCuadrados = 164329.157,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-3",
//        //            MetrosCuadrados = 122671.969,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 1
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-4",
//        //            MetrosCuadrados =  253019.989,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 2
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-4a",
//        //            MetrosCuadrados =  2229.302,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 3
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-5a",
//        //            MetrosCuadrados = 78244.718,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 4
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-5b",
//        //            MetrosCuadrados = 78244.717,
//        //            FactorTopografico = .08,
//        //            FraccionLegalId = 30,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 5

//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-6a",
//        //            MetrosCuadrados = 60000,
//        //            FactorTopografico = 0,
//        //            FraccionLegalId = 35,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 6
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-6b",
//        //            MetrosCuadrados = 114701.547,
//        //            FactorTopografico = 0,
//        //            FraccionLegalId = 36,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 7
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "KE-01",
//        //            MetrosCuadrados =  1626.791,
//        //            FraccionLegalId = 85,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 16
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "KE-02",
//        //            MetrosCuadrados =  1489.557,
//        //            FraccionLegalId = 84,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 17
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-7a",
//        //            MetrosCuadrados = 72438.42,
//        //            FactorTopografico = .05,
//        //            FraccionLegalId = 37,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 8
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-7b",
//        //            MetrosCuadrados = 72438.418,
//        //            FactorTopografico = .08,
//        //            FraccionLegalId = 38,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 9
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-8",
//        //            MetrosCuadrados = 198888.76,
//        //            FactorTopografico = .10,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 10
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-9",
//        //            MetrosCuadrados = 176581.584,
//        //            FactorTopografico = .15,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 11
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-10a",
//        //            MetrosCuadrados =  30000.00,
//        //            FactorTopografico = .18,
//        //            FraccionLegalId = 46,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 21
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-10b",
//        //            MetrosCuadrados =  100000.035,
//        //            FactorTopografico = .18,
//        //            FraccionLegalId = 47,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 12
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-11",
//        //            MetrosCuadrados = 107218.989,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-12ar",
//        //            MetrosCuadrados =  20000.00,
//        //            FactorTopografico = .18,
//        //            FraccionLegalId = 55,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 13
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-12b",
//        //            MetrosCuadrados =  38092.798,
//        //            FactorTopografico = .18,
//        //            FraccionLegalId = 48,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 14
//        //        },
//        //        new FraccionViviendaEconomica()
//        //        {
//        //            Nombre = "VE-12c",
//        //            MetrosCuadrados =  11907.202,
//        //            FactorTopografico = .18,
//        //            FraccionLegalId = 56,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 15
//        //        },
               



//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-1",
//        //            MetrosCuadrados = 100542.813,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-2",
//        //            MetrosCuadrados =  25765.813,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-3",
//        //            MetrosCuadrados = 49544.072,
//        //           FactorTopografico = .08
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-4",
//        //            MetrosCuadrados =  38887.157,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-4a",
//        //            MetrosCuadrados =  13564.232,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-5",
//        //            MetrosCuadrados =  129403.827,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-6",
//        //            MetrosCuadrados =  78496.558,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-7",
//        //            MetrosCuadrados =  85161.001,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-8",
//        //            MetrosCuadrados =  58409.38,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-9",
//        //            MetrosCuadrados =  58379.826,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-10",
//        //            MetrosCuadrados =  11659.629,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-11",
//        //            MetrosCuadrados =  37450.773,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-12a",
//        //            MetrosCuadrados =  60000,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-12b",
//        //            MetrosCuadrados =  60000,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-12c",
//        //            MetrosCuadrados =  40000,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-13",
//        //            MetrosCuadrados =  160770.33,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-14",
//        //            MetrosCuadrados =  66600.34,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-14a",
//        //            MetrosCuadrados =  1671.89,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-15",
//        //            MetrosCuadrados =  4841.82,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaSocial()
//        //        {
//        //            TipoDeSueloId = 2,
//        //            Nombre = "VS-16",
//        //            MetrosCuadrados =  21042.14,
//        //            FactorTopografico = .18
//        //        },



//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-1",
//        //            MetrosCuadrados =   11897.34,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-2",
//        //            MetrosCuadrados =   9741.88,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-3",
//        //            MetrosCuadrados =   7679.91,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-4",
//        //            MetrosCuadrados =   23382.32,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-5",
//        //            MetrosCuadrados =   13447.89,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-6",
//        //            MetrosCuadrados =   17929.11,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-7",
//        //            MetrosCuadrados =   16332.15,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaPopular()
//        //        {
//        //            TipoDeSueloId = 3,
//        //            Nombre = "VP-8",
//        //            MetrosCuadrados =  128004.28,
//        //            FactorTopografico = .2
//        //        },




//        //        new FraccionViviendaMedia()
//        //        {
//        //            TipoDeSueloId = 4,
//        //            Nombre = "VM-1",
//        //            MetrosCuadrados =  185395.62,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionViviendaMedia()
//        //        {
//        //            TipoDeSueloId = 4,
//        //            Nombre = "VM-2",
//        //            MetrosCuadrados = 185395.62,
//        //            FactorTopografico = .05
//        //        },




//        //        new FraccionViviendaResidencial()
//        //        {
//        //            TipoDeSueloId = 5,
//        //            Nombre = "VR-1",
//        //            MetrosCuadrados = 124188.12,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionViviendaResidencial()
//        //        {
//        //            TipoDeSueloId = 5,
//        //            Nombre = "VR-2",
//        //            MetrosCuadrados = 124188.122,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionViviendaResidencial()
//        //        {
//        //            TipoDeSueloId = 5,
//        //            Nombre = "VR-3",
//        //            MetrosCuadrados = 124188.12,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionViviendaResidencial()
//        //        {
//        //            TipoDeSueloId = 5,
//        //            Nombre = "VR-4",
//        //            MetrosCuadrados = 124188.12,
//        //            FactorTopografico = .20
//        //        },


//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-0",
//        //            MetrosCuadrados = 823.17,
//        //            FactorTopografico = 0,
//        //            FraccionLegalId = 138,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 18
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-1",
//        //            MetrosCuadrados = 6865.98,
//        //            FactorTopografico = .28
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-2",
//        //            MetrosCuadrados = 11702.53,
//        //            FactorTopografico = .19
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-3",
//        //            MetrosCuadrados = 9041.24,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-4",
//        //            MetrosCuadrados = 5752.31,
//        //            FactorTopografico = .17
//        //        },

//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-5",
//        //            MetrosCuadrados = 9963.74,
//        //            FactorTopografico = .14
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-6a",
//        //            MetrosCuadrados = 14493.81,
//        //            FactorTopografico = .30
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-6b",
//        //            MetrosCuadrados = 3649.45,
//        //            FactorTopografico = .30
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-7",
//        //            MetrosCuadrados = 12744.35,
//        //            FactorTopografico = .21
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-8",
//        //            MetrosCuadrados = 3015.05,
//        //            FactorTopografico = .21
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //              TipoDeComercioId = 1,
//        //           TipoDeSueloId = 6,
//        //            Nombre = "COM-9",
//        //            MetrosCuadrados = 6074.88,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //              TipoDeComercioId = 1,
//        //           TipoDeSueloId = 6,
//        //            Nombre = "COM-10",
//        //            MetrosCuadrados = 1338,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-11",
//        //            MetrosCuadrados = 6892.58,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-12",
//        //            MetrosCuadrados = 10000,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-13",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 11467.44,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-14",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 19098.44,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-15",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 10000,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-16",
//        //            MetrosCuadrados = 21118.61,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-17",
//        //            MetrosCuadrados = 2500,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-18",
//        //            MetrosCuadrados = 2500,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-19",
//        //            MetrosCuadrados = 5000,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-20",
//        //              TipoDeComercioId = 1,
//        //           MetrosCuadrados = 117413.65,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-21",
//        //            MetrosCuadrados = 14686.72,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-22",
//        //            MetrosCuadrados = 24600.02,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //             Nombre = "COM-23",
//        //            MetrosCuadrados = 11688.34,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-24",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 11369.18,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-25",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 120556.63,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-26",
//        //            MetrosCuadrados = 24432.69,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-27",
//        //            MetrosCuadrados = 4450.53,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-28",
//        //            MetrosCuadrados = 11321.59,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-29a",
//        //            MetrosCuadrados = 7405.31,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-29b",
//        //            MetrosCuadrados = 4000,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-29c",
//        //            MetrosCuadrados = 9564.49,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-30",
//        //            MetrosCuadrados = 12634.99,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-31",
//        //            MetrosCuadrados = 3450.81,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-32",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 52592.61,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-33",
//        //            MetrosCuadrados = 28029.2,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //             TipoDeComercioId = 1,
//        //            Nombre = "COM-34",
//        //            MetrosCuadrados = 81283.68,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            TipoDeComercioId = 1,
//        //            Nombre = "COM-35",
//        //            MetrosCuadrados = 4346.58,
//        //            FactorTopografico = .20,
//        //            FraccionLegalId = 140,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 19

//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-36",
//        //            TipoDeComercioId = 1,
//        //            MetrosCuadrados = 4500,
//        //            FactorTopografico = .20,
//        //            FraccionLegalId = 53,
//        //            InversionesCalculadasDiferente = true,
//        //            CalculosEspecialesId = 20
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeComercioId = 1,
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-37",
//        //            MetrosCuadrados = 4755.78,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionCOM()
//        //        {
//        //            TipoDeSueloId = 6,
//        //            Nombre = "COM-38",
//        //            MetrosCuadrados = 59202.05,
//        //            TipoDeComercioId = 1,
//        //            FactorTopografico = .02
//        //        },



//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-1",
//        //            MetrosCuadrados = 115611.27,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-5",
//        //            MetrosCuadrados = 3400.16,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-6",
//        //            MetrosCuadrados = 19271.22,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-7",
//        //            MetrosCuadrados = 9080.26,
//        //            FactorTopografico = .09
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-8",
//        //            MetrosCuadrados = 9080.26,
//        //            FactorTopografico = .09
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-9",
//        //            MetrosCuadrados = 3215.42,
//        //            FactorTopografico = .06
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-10",
//        //            MetrosCuadrados = 11259.89,
//        //            FactorTopografico = .07
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-11",
//        //            MetrosCuadrados = 4869.01,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-12",
//        //            MetrosCuadrados = 5803.53,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-13a",
//        //            MetrosCuadrados = 5000,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-13b",
//        //            MetrosCuadrados = 6191.17,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-13c",
//        //            MetrosCuadrados = 12433.48,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-13d",
//        //            MetrosCuadrados = 17157.52,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-13e",
//        //            MetrosCuadrados = 20823.85,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-14",
//        //            MetrosCuadrados = 23720.51,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-15",
//        //            MetrosCuadrados = 23720.52,
//        //            FactorTopografico = .01
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-16",
//        //            MetrosCuadrados = 13078.08,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-17",
//        //            MetrosCuadrados = 24414.85,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-18",
//        //            MetrosCuadrados = 29643.41,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-19a",
//        //            MetrosCuadrados = 6750.47,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-19b",
//        //            MetrosCuadrados = 15252.78,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-20",
//        //            MetrosCuadrados = 22426.6,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-21",
//        //            MetrosCuadrados = 9722.73,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-22",
//        //            MetrosCuadrados = 9888.03,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-23",
//        //            MetrosCuadrados = 9546.09,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-24",
//        //            MetrosCuadrados = 9902.87,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-25",
//        //            MetrosCuadrados = 23665.19,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-26",
//        //            MetrosCuadrados = 16538.01,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-27",
//        //            MetrosCuadrados = 69351.53,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-28",
//        //            MetrosCuadrados = 63419.77,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-29",
//        //            MetrosCuadrados = 17765.76,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-30",
//        //            MetrosCuadrados = 52104.74,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-31",
//        //            MetrosCuadrados = 16959.32,
//        //            FactorTopografico = .03
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-32",
//        //            MetrosCuadrados = 10000,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-33",
//        //            MetrosCuadrados = 36256.4,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-34",
//        //            MetrosCuadrados = 21529.69,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-35",
//        //            MetrosCuadrados = 11151,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-36",
//        //            MetrosCuadrados = 13321.72,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-37",
//        //            MetrosCuadrados = 34623.67,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-38",
//        //            MetrosCuadrados = 23786,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-39",
//        //            MetrosCuadrados = 9022.62,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-40",
//        //            MetrosCuadrados = 7020.7,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-41",
//        //            MetrosCuadrados = 8259.51,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-42a",
//        //            MetrosCuadrados = 2498.85,
//        //            FactorTopografico = .08,
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-42b",
//        //            MetrosCuadrados = 2500,
//        //            FactorTopografico = .03,
//        //            FraccionLegalId = 93,
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-43",
//        //            MetrosCuadrados = 8816.61,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-44",
//        //            MetrosCuadrados = 11563.86,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-45",
//        //            MetrosCuadrados = 10010.37,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-46",
//        //            MetrosCuadrados = 14624.15,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-47",
//        //            MetrosCuadrados = 129780.33,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-48",
//        //            MetrosCuadrados = 24625.06,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionCS()
//        //        {
//        //            TipoDeSueloId = 7,
//        //            Nombre = "CS-49",
//        //            MetrosCuadrados = 27046.92,
//        //            FactorTopografico = .05
//        //        },



//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-1",
//        //            MetrosCuadrados = 165791.07,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-2",
//        //            MetrosCuadrados = 77901.34,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-3",
//        //            MetrosCuadrados = 23658.28,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-4",
//        //            MetrosCuadrados = 122783.44,
//        //            FactorTopografico = .13
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-5",
//        //            MetrosCuadrados = 83406.32,
//        //            FactorTopografico = .16
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-6",
//        //            MetrosCuadrados = 34945.91,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-7",
//        //            MetrosCuadrados = 100713.5,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-8",
//        //            MetrosCuadrados = 23772.54,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-9",
//        //            MetrosCuadrados = 53345.18,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-10",
//        //            MetrosCuadrados = 69846.49,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-11",
//        //            MetrosCuadrados = 51841.69,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-12",
//        //            MetrosCuadrados = 45349.97,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-13",
//        //            MetrosCuadrados = 53694.1,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-14",
//        //            MetrosCuadrados = 116661.36,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-15",
//        //            MetrosCuadrados = 101325.38,
//        //            FactorTopografico = .25
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-16",
//        //            MetrosCuadrados = 98890.56,
//        //            FactorTopografico = .20
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-17",
//        //            MetrosCuadrados = 63375.58,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-18",
//        //            MetrosCuadrados = 66116.98,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-19",
//        //            MetrosCuadrados = 66863.16,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-20",
//        //            MetrosCuadrados = 61799.79,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionIN()
//        //        {
//        //            TipoDeSueloId = 8,
//        //            Nombre = "I-21",
//        //            MetrosCuadrados = 56900.87,
//        //            FactorTopografico = .08
//        //        },




//        //        new FraccionPAT()
//        //        {
//        //            TipoDeSueloId = 9,
//        //            Nombre = "PAT-1",
//        //            MetrosCuadrados =  126076.17,
//        //            FactorTopografico = .07
//        //        },
//        //        new FraccionPAT()
//        //        {
//        //            TipoDeSueloId = 9,
//        //            Nombre = "PAT-2",
//        //            MetrosCuadrados = 191736.79,
//        //            FactorTopografico = .08
//        //        },



//        //        new FraccionSE()
//        //        {
//        //            TipoDeSueloId = 10,
//        //            Nombre = "SE-1",
//        //            MetrosCuadrados =  159709.72,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionSE()
//        //        {
//        //            TipoDeSueloId = 10,
//        //            Nombre = "SE-2",
//        //            MetrosCuadrados = 56254.66,
//        //            FactorTopografico = .12
//        //        },



//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-1",
//        //            MetrosCuadrados = 42215.77,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-2",
//        //            MetrosCuadrados = 62892.15,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-3",
//        //            MetrosCuadrados = 33448.62,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-4",
//        //            MetrosCuadrados = 5763.23,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-5",
//        //            MetrosCuadrados = 12582.19,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-6",
//        //            MetrosCuadrados = 31448.46,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-7",
//        //            MetrosCuadrados = 8434.69,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-8",
//        //            MetrosCuadrados = 43903.33,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-9",
//        //            MetrosCuadrados = 19581.42,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-10",
//        //            MetrosCuadrados = 45065.43,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-11",
//        //            MetrosCuadrados = 59737.47,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-12",
//        //            MetrosCuadrados = 18804.47,
//        //            FactorTopografico = .70
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-13",
//        //            MetrosCuadrados = 80774.58,
//        //            FactorTopografico = .70,
//        //        },
//        //        new FraccionAC()
//        //        {
//        //            Nombre = "AC-14",
//        //            MetrosCuadrados = 18522.43,
//        //            FactorTopografico = .70
//        //        },



//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-1",
//        //            MetrosCuadrados = 83623.91,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-2",
//        //            MetrosCuadrados = 135009.46,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-3",
//        //            MetrosCuadrados = 136715.44,
//        //            FactorTopografico = .10
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-4",
//        //            MetrosCuadrados = 78948.42,
//        //            FactorTopografico = .18
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-5",
//        //            MetrosCuadrados = 24676.47,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-6",
//        //            MetrosCuadrados = 33471.74,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-7",
//        //            MetrosCuadrados = 23689.9,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionRE()
//        //        {
//        //            TipoDeSueloId = 12,
//        //            Nombre = "RE-8",
//        //            MetrosCuadrados = 37822.56,
//        //            FactorTopografico = .15
//        //        },




//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-1",
//        //            MetrosCuadrados = 10117.31,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-2",
//        //            MetrosCuadrados = 44999.9,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-3",
//        //            MetrosCuadrados = 9881.48,
//        //            FactorTopografico = .02
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-4",
//        //            MetrosCuadrados = 10000.63,
//        //            FactorTopografico = .05
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-5",
//        //            MetrosCuadrados = 16588.84,
//        //            FactorTopografico = .08
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-6",
//        //            MetrosCuadrados = 14979.81,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-7",
//        //            MetrosCuadrados = 35780.68,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-8",
//        //            MetrosCuadrados = 12750,
//        //            FactorTopografico = .12
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-9",
//        //            MetrosCuadrados = 220447.22,
//        //            FactorTopografico = .60
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-10",
//        //            MetrosCuadrados = 15480.28,
//        //            FactorTopografico = .15
//        //        },
//        //        new FraccionEU()
//        //        {
//        //            TipoDeSueloId = 13,
//        //            Nombre = "EQ-11",
//        //            MetrosCuadrados = 15000,
//        //            FactorTopografico = .15
//        //        },


//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-1",
//        //            MetrosCuadrados = 7363.43,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-2",
//        //            MetrosCuadrados = 511.61,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-3",
//        //            MetrosCuadrados = 1064.92,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-4",
//        //            MetrosCuadrados = 2596.96,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-5",
//        //            MetrosCuadrados = 11601.05,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-6",
//        //            MetrosCuadrados = 317.41,
//        //        },
//        //        new FraccionDON()
//        //        {
//        //            Nombre = "DON-7",
//        //            MetrosCuadrados = 248.53,
//        //        },



//        //        new FraccionVIAL()
//        //        {
//        //            Nombre = "VIAL-1",
//        //            MetrosCuadrados = 206021.84,
//        //        },
//        //        new FraccionVIAL()
//        //        {
//        //            Nombre = "VIAL-2",
//        //            MetrosCuadrados = 206021.84,
//        //        },
//        //        new FraccionVIAL()
//        //        {
//        //            Nombre = "VIAL-3",
//        //            MetrosCuadrados = 206021.84,
//        //        },
//        //        new FraccionVIAL()
//        //        {
//        //            Nombre = "VIAL-4",
//        //            MetrosCuadrados = 206021.84,
//        //        },



//        //    };
//        //    return fracciones;
//        //}
//    }
//}
