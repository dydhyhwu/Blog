// eslint-disable-next-line @typescript-eslint/no-var-requires
const MonacoEditorWebpackPlugin = require('monaco-editor-webpack-plugin');

module.exports = {
    publicPath: './',
    lintOnSave: false,
    productionSourceMap: false,
    transpileDependencies: ['vuetify'],
    configureWebpack: {
        plugins: [new MonacoEditorWebpackPlugin()],
    },
};
