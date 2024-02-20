import { defineConfig } from "vitepress"

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Кощей Роман",
  description: "Структури даних та алгоритми Кощея Романа",

  // replace knu-template with name of your repository
  base: "/algorithms/",

  themeConfig: {
    nav: [{ text: "Лабораторні", link: "/labs/1" }],

    sidebar: [
      {
        text: "Лабораторні роботи",
        items: [{ text: "Лабораторна робота №1", link: "/labs/1" }],
      },
    ],

    socialLinks: [
      { icon: "github", link: "https://github.com/koshcher/algorithms" },
    ],
  },
})
