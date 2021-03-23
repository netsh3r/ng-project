﻿var gulp = require("gulp"),
    sass = require("gulp-sass"); // добавляем модуль sass

var paths = {
    webroot: "./wwwroot/"
};
// регистрируем задачу для конвертации файла scss в css
gulp.task("sass", function () {
    return gulp.src(paths.webroot + './Sass/*.scss')
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + './css'));
});

gulp.task('default', ['sass']);