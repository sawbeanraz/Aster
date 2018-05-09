var webpack = require('webpack');

module.exports = (env = {}) => {
    return {        
        entry: ['./wwwroot/js/site.js', './wwwroot/sass/aster.scss'],
        devtool: "source-map",
        output: {
            path: __dirname + '/wwwroot',
            filename: './js/site.min.js',
        },
        module: {
            rules: [{
                test: /\.scss$/,
                use: [{
                        loader: 'file-loader',
                        options: {
                            name: '[name].min.css',
                            outputPath: './css/'
                        }
                    }, {
                        loader: 'extract-loader'
                    }, {
                        loader: 'css-loader'
                    }, {
                        loader: 'postcss-loader'
                    }, {
                        loader: 'sass-loader'
                    }
                ]
            }, {
                    test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
                    use: [{
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            outputPath: 'fonts/'
                        }
                    }]
                }
            ]
        },
        plugins: [
            new webpack.ProvidePlugin({
                $: 'jquery',
                jQuery: 'jquery',
                'window.jQuery': 'jquery',
                Popper: ['popper.js', 'default']
            })
        ]
    }
}