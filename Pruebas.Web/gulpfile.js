/// <binding Clean='clean' />
"use strict";
//DE MOMENTO NO ESTOY UTILIZANDO GULP, POR LO QUE HABRÍA QUE REVISAR ESTE ARCHIVO
var ts = require('gulp-typescript');
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var clean = require('gulp-clean');
var tslint = require("gulp-tslint");
 
var destPath = './Scripts/Libs/';
 
// Delete the dist directory
gulp.task('clean', function () {
    return gulp.src(destPath).pipe(clean());
});

gulp.task("tslint", () =>
    gulp.src("./Scripts/AppNg/**/*.ts")
        .pipe(tslint({
            formatter: "verbose"
        }))
        .pipe(tslint.report())
);

gulp.task("libsJS", () => {
    gulp.src([
            'core-js/client/**',
            'zone.js/dist/**',
            'systemjs/dist/system.src.js',
            '@angular/**'/*,
            'reflect-metadata/**',
            'rxjs/**',
            'jquery/dist/jquery.*js',
            'bootstrap/dist/js/bootstrap.*js'*/
    ], {
        cwd: "node_modules/**"
    }).pipe(gulp.dest("./Scripts/Libs"));
});
 
var tsProject = ts.createProject('./tsconfig.json', {
    typescript: require('typescript')
});
gulp.task('ts', function (done) {
    var tsResult = gulp.src(["Scripts/AppNg/*.ts"])
        .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest('./Scripts/AppNg'));
});

gulp.task('watch.ts', ['ts'], function () {
    return gulp.watch('Scripts/AppNg/*.ts', ['ts']);
});
 
gulp.task('watch', ['watch.ts']);
 
 
gulp.task('default', ['libsJS']);