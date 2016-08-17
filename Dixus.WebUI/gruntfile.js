/// <reference path="scripts/knockout/knockout.js" />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        sass: {
            dist: {
                options: {
                    style: "expanded" //Expanded, nested, compact, compressed
                },
                files: {
                    'Content/build/site.css': 'Content/site.scss'
                }
            }
        },
        cssmin: {
            options: {
                roundingPrecision: -1
            },
            styles: {
                files: {
                    'Content/build/site.min.css': 'Content/build/site.css'
                }
            },
            bootstrap: {
                files: {
                    'Content/build/bootstrap.min.css': 'Content/bootstrap.css'
                }
            }
        },
        uglify: {
            my_app: {
                options: {
                    banner: '/*! <%= pkg.name =>. Created by <%=pkg.author=>. Version <%= pkg.vesion => */' //This is prepended to file
                },
                files: {
                    'scripts/app.min.js': ['scripts/app.js']
                }
            },
            knockout: {
                options: {
                    banner: '/*! <%= pkg.name =>. Created by <%=pkg.author=>. Version <%= pkg.vesion => */' //This is prepended to file
                },
                files: {
                    'scripts/ViewModels/ViewModels.min.js': ['scripts/ViewModels/TablaFraccionesViewModel.js'],
                    'scripts/knockout/knockout.min.js': ['scripts/knockout/knockout.js'],
                    'scripts/knockout/bindingHandlers.min.js': ['scripts/knockout/bindingHandlers.js']
                }
            }
        },
        concat: {
            js: {
                src: ['scripts/knockout/knockout.min.js', 'scripts/knockout/bindingHandlers.min.js', 'scripts/jquery-1.10.2.min.js', 'scripts/bootstrap.min.js', 'scripts/app.min.js'],
                dest: 'scripts/dist/scripts.min.js'
            },
            viewmodels: {
                src: ['scripts/ViewModels/ViewModels.min.js'],
                dest: 'scripts/dist/koViewModels.min.js'
            },
            css: {
                src: ['Content/build/site.min.css', 'Content/build/bootstrap.min.css', 'Content/build/font-awesome.min.css'],
                dest: 'Content/dist/styles.css'
            },
        },
        watch: {
            js: {
                files: ['scripts/app.js'],
                tasks: ['uglify:my_app', 'concat:js']
            },
            viewmodels: {
                files: ['scripts/ViewModels/*.js', 'scripts/knockout/bindingHandlers.js'],
                tasks: ['uglify:knockout', 'concat:viewmodels', 'concat:js']
            },
            css: {
                files: ['Content/site.scss'],
                tasks: ['sass', 'cssmin:styles', 'concat:css']
            },
            bootstap: {
                files: ['Content/bootstrap.css'],
                tasks: ['cssmin:bootstrap', 'concat:css']
            }
        }
    });

    //You have to install this packages locally using npm
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-contrib-sass");
    grunt.loadNpmTasks("grunt-contrib-cssmin");

    //These tasks will be called when using "grunt" in terminal
    grunt.registerTask('default', ['sass', 'uglify', 'cssmin', 'concat', 'watch']);

};