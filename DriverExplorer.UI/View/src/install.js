import "material-design-icons/iconfont/material-icons.css";
import "@mdi/font/css/materialdesignicons.css";
import "font-awesome/css/font-awesome.css";

import Vue_Router from "vue-router";
import { router } from "./route";
import VueI18n from "vue-i18n";
import messages from "./message";
import Notifications from "vue-notification";
import textButton from "@/components/textButton";
import iconButton from "@/components/iconButton";

function install(Vue) {
  Vue.use(Vue_Router);
  Vue.use(VueI18n);
  Vue.use(Notifications);
  Vue.component("text-button", textButton);
  Vue.component("icon-button", iconButton);
}

/*eslint no-unused-vars: ["error", { "args": "none" }]*/
function vueInstanceOption(vm) {
  const i18n = new VueI18n({
    locale: "en-US", // set locale
    messages // set locale messages
  });

  //Return vue global option here, such as vue-router, vue-i18n, mix-ins, ....
  return {
    router,
    i18n
  };
}

export { install, vueInstanceOption };
