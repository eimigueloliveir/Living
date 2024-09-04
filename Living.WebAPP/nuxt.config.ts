import Aura from "@primevue/themes/aura";

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: false },
  modules: ["@primevue/nuxt-module", "@nuxtjs/i18n"],

  devServer: {
    port: 8080,
  },

  runtimeConfig: {
    public: {
      API_URL: "https://localhost:7129",
    },
  },

  components: [
    {
      path: "~/components",
      pathPrefix: false,
    },
  ],

  i18n: {
    detectBrowserLanguage: {
      useCookie: true,
      cookieKey: "i18n_redirected",
      redirectOn: "root",
    },
    customRoutes: "config",
    defaultLocale: "pt-br",
    strategy: "no_prefix",
    locales: [
      {
        code: "en",
        name: "English",
      },
      {
        code: "pt-br",
        name: "Português",
      },
    ],
  },

  primevue: {
    options: {
      theme: {
        preset: Aura,
      },
    },
  },

  css: [
    "primeicons/primeicons.css",
    "/node_modules/primeflex/primeflex.css",
    "~/assets/css/main.css",
  ],

  compatibilityDate: "2024-08-25",
});
