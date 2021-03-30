<template>
  <div id="wrapper" :class="wrapperClass">

    <MenuToggleBtn></MenuToggleBtn>

    <Menu></Menu>

    <ContentOverlay></ContentOverlay>

    <router-view></router-view>

  </div>
</template>
<script>
// @ is an alias to /src
import MenuToggleBtn from '@/components/SideMenu/MenuToggleBtn.vue'
import Menu from '@/components/SideMenu/Menu.vue'
import ContentOverlay from '@/components/SideMenu/ContentOverlay.vue'

export default {

  components: {
    MenuToggleBtn,
    Menu,
    ContentOverlay,
  },

  created() {

    this.emitter.on('menu/toggle', () => {
      window.setTimeout(() => {
        this.isOpenMobileMenu = !this.isOpenMobileMenu;
      }, 200);
    });

    this.emitter.on('menu/closeMobileMenu', () => {
      this.isOpenMobileMenu = false;
    });

  },


  data() {
    return {
      isOpenMobileMenu: false,
    };
  },

  computed: {
    wrapperClass() {
      return {
        'toggled': this.isOpenMobileMenu === true,
      };
    },
  }

}

</script>
<style lang="scss">
@import 'components/SideMenu/styles/layout.scss';
@import 'components/SideMenu/styles/menu-toggle-btn.scss';
@import 'components/SideMenu/styles/menu.scss';
@import 'components/SideMenu/styles/content-overlay.scss';
@import 'components/SideMenu/styles/media-queries.scss';
</style>
