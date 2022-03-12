# Rent A Car Project Backend Section

## What Was My Motivation Starting To This Project

	
My motivation was in this project to develop a project that enables customers to rent different types of car.At the same time i wanted to enable CRUD operations to Application Users to Add,Delete,List or Update operations.Of course my biggest reason was use my knowledge that i learned from computer sciences college and online courses.I faced numerous problems while i'm developing this project.But all of them take me one step further and i think i got a fundamantels about Backend Development area.
  
Some of the technologies used in this project:<i>C#,.Net Core,Entity Framework,MSSQL,Autofac,Fluent Validation,JWT</i>

## Project Description

Backend Section in Rent A Car Project consists of 6 layer,each layer has a different tasks and purpose.The layers are Entity,DataAccess,Business,Core and WebAPI layers.

## Entity Layer

Entity Layer includes classes in the project saved in Database and DTO's.This classes used to Access Database by Entity Framework in Data Access Layer.DTOs come in handy in systems with remote calls, as they help to reduce the number of them. DTOs also help when the domain model is composed of many different objects and the presentation model needs all their data at once, or they can even reduce roundtrip between client and server.

![image](https://user-images.githubusercontent.com/78471151/157240227-f90915f8-042e-4d69-8686-8d6193aef883.png)

## Data Access Layer

For database operations at data access layer Entity Framework was used.The Entity Framework enables developers to work with data in the form of domain-specific objects and properties, such as customers and customer addresses, without having to concern themselves with the underlying database tables and columns where this data is stored. Here are my classes which i created at EntityFramework folder.

![image](https://user-images.githubusercontent.com/78471151/158021941-66220f33-d46f-47bc-9d25-325460c8ea76.png)

### Context.cs

Context class that i used for managing data access operations and configuring database tables as c# classes by DbSet method.


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDb;Database=RentCarSystemDb;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<FromBankCreditCard> FromBankCreditCards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SavedCreditCard> SavedCreditCards { get; set; }
        
    }


## EfEntityRepositoryBase.cs

EfRepositoryBase is a generic base class that contains CRUD operations.
       
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }
       


        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    

