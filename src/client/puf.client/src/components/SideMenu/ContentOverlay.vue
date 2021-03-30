<template>

  <div
  @click.prevent="closeMobileMenu"
  class="content-overlay"
  ></div>

</template>

<script>

export default {

   methods: {

    closeMobileMenu() {
      this.emitter.emit('menu/toggle');
    },

  },

};

</script>
