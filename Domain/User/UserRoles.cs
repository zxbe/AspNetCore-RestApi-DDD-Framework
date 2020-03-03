﻿namespace Domain.User
{
    public enum UserRoles
    {
        /// <summary>
        /// Суперадмин
        /// </summary>
        SuperAdmin = 1,
        /// <summary>
        /// Администратор партнера
        /// </summary>
        PartnerAdmin = 2,
        /// <summary>
        /// Ритуальный агент
        /// </summary>
        PartnerAgent = 4,
        /// <summary>
        /// Ответственное лицо
        /// </summary>
        PartnerIncharge = 8,
        /// <summary>
        /// Региональный администратор (администратор муниципалитета)
        /// </summary>
        RegionalAdmin = 16,
        /// <summary>
        /// Сотрудник (оператор) муниципалитета
        /// </summary>
        RegionalOperator = 32,
        /// <summary>
        /// Смотритель (сотрудник кладбища)
        /// </summary>
        RegionalKeeper = 64
    }
}