const path = import('path');
const resolve = (dir) => path.join(__dirname, dir);

module.exports = {
    resolve: {
        extensions: ['.ts', '.js', '.vue'],
        alias: {
            '@': resolve('src'),
        },
    },
};
