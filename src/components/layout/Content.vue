<template>
    <div id="content">
        <Footer />
        <EmployeeList />
        
        <!-- <EmployeeDetail hidden /> -->
       <!-- <router-view></router-view>  -->
        
    </div>
</template>

<script>
import Footer from './Footer.vue'
// import EmployeeDetail from '../../views/employee/EmployeeDetail.vue'
import EmployeeList from '../../views/employee/EmployeeList.vue'

export default {
    name: 'Content',
    components: {
        Footer,
        // EmployeeDetail,
        EmployeeList
    }
}

</script>

<style scoped>
#content{
    position: absolute;
    top: 60px;
    left: 200px;
    right: 0px;
    bottom: 0px;
    padding: 24px;
     background-color: #E5E5E5;
}
</style>