<template>

  <a
  href="#"
  @click.prevent="toggleMenu"
  class="btn btn-outline-danger menu-toggle-btn"
  >
    <i class="fa fa-bars" aria-hidden="true"></i>
  </a>

</template>

<script>

export default {

   methods: {

    toggleMenu() {
      this.emitter.emit('menu/toggle');
    },
  },
};

</script>
