/** @type {import('tailwindcss').Config} */
module.exports = {
    content:
    [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
    theme: {
        extend: {
            fontFamily: {
                display: 'Oswald, ui-serif',
                sans: 'Passion One, sans',
                serif: 'Merriweather", "serif',
            }
        }
    },
    plugins:
    [
        require("flowbite/plugin")({
            charts: true,
            forms: true,
            tooltips: true
        })
    ],
    darkMode: "class"
}