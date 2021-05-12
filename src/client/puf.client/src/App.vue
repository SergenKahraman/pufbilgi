<template>
  <div id="wrapper" :class="wrapperClass">
    <account-menu v-if="session"></account-menu>

    <MenuToggleBtn></MenuToggleBtn>

    <Menu></Menu>

    <ContentOverlay></ContentOverlay>

    <router-view></router-view>
  </div>
</template>
<script>
// @ is an alias to /src
import MenuToggleBtn from "@/components/SideMenu/MenuToggleBtn.vue";
import Menu from "@/components/SideMenu/Menu.vue";
import ContentOverlay from "@/components/SideMenu/ContentOverlay.vue";
import AccountMenu from "@/components/accountMenu/AccountMenu.vue";
export default {
  components: {
    MenuToggleBtn,
    Menu,
    ContentOverlay,
    AccountMenu
  },

  created() {
    this.emitter.on("menu/toggle", () => {
      window.setTimeout(() => {
        this.isOpenMobileMenu = !this.isOpenMobileMenu;
      }, 200);
    });

    this.emitter.on("menu/closeMobileMenu", () => {
      this.isOpenMobileMenu = false;
    });
    
  },

  data() {
    
    return {
      isOpenMobileMenu: false,
      show: false,
      session: window.localStorage.getItem("s") != null,
      
    };
  },
  
  computed: {
    wrapperClass() {
      return {
        toggled: this.isOpenMobileMenu === true,
      };
    },
  },
  methods:{
    
  }
};
</script>
<style lang="scss">
@import "components/SideMenu/styles/layout.scss";
@import "components/SideMenu/styles/account-menu.scss";
@import "components/SideMenu/styles/menu-toggle-btn.scss";
@import "components/SideMenu/styles/menu.scss";
@import "components/SideMenu/styles/content-overlay.scss";
@import "components/SideMenu/styles/media-queries.scss";
@import url("https://fonts.googleapis.com/css2?family=Quicksand:wght@500&display=swap");
</style>
