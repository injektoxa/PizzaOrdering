var Harness = Siesta.Harness.Browser.ExtJS;

Harness.configure({
    title       : 'Awesome Test Suite',

    preload     : [
        // version of ExtJS used by your application
        '../ext-4.1.1/resources/css/ext-all.css',
        '../resources/yourproject-css-all.css',

        // version of ExtJS used by your application
        '../ext-4.1.1/ext-all-debug.js',
        '../yourproject-all.js'
    ]
});

Harness.start(
    '010_sanity.t.js',
    '020_basic.t.js'
);