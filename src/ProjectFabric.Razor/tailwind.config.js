/** @type {import('tailwindcss').Config} */
module.exports = {
    content:
    [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
    theme: {
        extend: {
            spacing: {
                '128': "32rem",
                '144': "36rem",
            },
            borderRadius: {
                '4xl': "2rem",
            },
            fontFamily: {
                display: 'Oswald, ui-serif',
                sans: 'Passion One',
                serif: 'Merriweather", "serif',
            }
        },
    },
    plugins:
    [
        require("flowbite/plugin")({
            charts: true,
            forms: true,
            tooltips: true
        }),
    ],
    darkMode: "class"
}