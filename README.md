[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/0mNoXTBm)
# assignment-1


## Appendix

Person class icersindeki validation lar FluentValidation kutuphanesi kullanilarak yeniden duzenlenecek.
Controller uzerindeki POST methodu attributelar yerinde FluentValidation ile calisacak sekilde duzenlenecek. 
Odev icerisinde sadece 1 controller ve 1 method teslim edilecek. 



```c#=
public class Person
{
    [DisplayName("Staff person name")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Name { get; set; }


    [DisplayName("Staff person lastname")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Lastname { get; set; }


    [DisplayName("Staff person phone number")]
    [Required]
    [Phone]
    public string Phone { get; set; }


    [DisplayName("Staff person access level to system")]
    [Range(minimum: 1, maximum: 5)]
    [Required]
    public int AccessLevel { get; set; }



    [DisplayName("Staff person salary")]
    [Required]
    [Range(minimum: 5000, maximum: 50000)]
    [SalaryAttribute]
    public decimal Salary { get; set; }
}
```


## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

