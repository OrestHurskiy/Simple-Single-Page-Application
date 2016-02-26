// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');


var config = {
    //JavaScript files that will be combined into a jquery bundle
    jqsrc: [
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/jquery-validation/dist/jquery.validate.min.js',
        'bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js'
    ]

}

//delete the output file(s)
gulp.task('clean', function () {
    return del(['Scripts/vendors/jquery-bundle.min.js']);
});

gulp.task('scripts', ['clean'], function () {

    return gulp.src(config.jqsrc)
      .pipe(uglify())
      .pipe(concat('jquery-bundle.min.js'))
      .pipe(gulp.dest('Scripts/vendors/'));
});

//Set a default tasks
gulp.task('default', ['scripts'], function () { });