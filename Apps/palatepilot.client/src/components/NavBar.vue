<script setup>
import authService from '@/services/authService';
import { useRouter }   from 'vue-router';
const router = useRouter();

function handleLogoutButton(){
  authService.logout("jwt")
  router.push('/login')
}

</script>

<template>
    <nav class="navbar is-success" role="navigation" aria-label="main navigation">
        <div class="navbar-brand">
            <button @click="handleLogoutButton" class="m-4  button">Logout</button>
        </div>
    </nav>
</template>
  
