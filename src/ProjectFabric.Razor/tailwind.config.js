/** @type {import('tailwindcss').Config} */
module.exports = {
    content:
    [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js"
    ],
    theme: {
        screens: {
            sm: "480px",
            md: "768px",
            lg: "976px",
            xl: "1440px",
        },
        colors: {
            transparent: "transparent",
            black: "#000",
            white: "#fff",
            gray: {
                100: "#f7fafc",
                900: "#fff"
            },
            'orange': '#ff7849'
        },
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
                sans: 'Graphik", "Times New Roman',
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