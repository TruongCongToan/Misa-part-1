<template>
    <tr @dblclick="$emit('trDblClick')"
        @click="$emit('trClick')"
        
    >
       <td style="width: 2%"><input type="checkbox" unchecked> </td>
                        <td style="9%">{{employee.employeeCode}}</td>
                        <td style="width: 9%">{{employee.fullName}}</td>
                        <td style="width: 6%">{{formatGender(employee.gender)}}</td>
                        <td style="width: 8%">{{ formatDate(employee.dateOfBirth) }}</td>
                        <td style="width: 6%">{{employee.idCardNumber}}</td>
                         <td style="width: 6%">{{employee.departmentId}}</td> 
                        <td style="width: 10%">{{checkDonVi(employee.departmentId)}}</td>
                        <td style="width: 12%">{{employee.bankAccount}}</td>
                        <td style="width: 10%">{{employee.bankName}}</td>
                        <td style="width: 10%">{{employee.agency}}</td>
                        <td style="width: 12%">
                             <select id="department-select"
                             class="drop-down-default department-drop-down"
                             @change="filterData"
                             > 
                               <option value="allDepartment">Nhân bản</option>
                            <option value="0">Nhân bản</option>
                            <option value="1">Xóa</option>
                            <option value="2">Sửa</option>
                            <option value="3">Ngừng sử dụng</option>
                             </select>
                        </td>
    
  
    </tr>
</template>

<script>
export default {
    props: {
        employee:{ type: Object, default: null }
    },
    methods: {
        formatDate(date){
            if(!date) {
                return "";
            }
            var newDate = new Date(date);
            var dateString = newDate.getDate();
            if(dateString < 10) {
                dateString = "0" + dateString;
            }
            var monthString = newDate.getMonth() + 1;
            if(monthString < 10) {
                monthString = "0" + monthString;
            }
            var yearString = newDate.getFullYear();
            return `${dateString}/${monthString}/${yearString}`;
        },
        formatSalary(salary) {
            if(!salary) return '';
            var moneyFormat = salary.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.') + " VNĐ";
            return moneyFormat;
        }
    },
    computed: {
        workStatusName: function() {
            var temp = this.employee.WorkStatus;
            var res = temp === 1 ? 'Đang làm việc' : temp === 0 ? 'Đã nghỉ việc' : 'Khác';
            return res;
        }
    }

}
</script>

<style scoped>

</style>