// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using _07JP27.SystemPromptSwitchingGPTBot.Bots;
using Microsoft.Extensions.Hosting;
using Azure.AI.OpenAI;
using System;
using Azure.Identity;
using _07JP27.SystemPromptSwitchingGPTBot.SystemPrompt;
using System.Collections.Generic;

namespace _07JP27.SystemPromptSwitchingGPTBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient().AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
            });

            // Create the Bot Framework Authentication to be used with the Bot Adapter.
            services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

            // Create the Bot Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, GPTBot>();

            // State
            // ここではメモリにも保持しておくが、永続化したい場合はBlobやCosmosDBなどに保存するオプションもある
            // ref:https://learn.microsoft.com/ja-jp/azure/bot-service/bot-builder-concept-state?view=azure-bot-service-4.0#storage-layer
            var storage = new MemoryStorage();
            services.AddSingleton(new UserState(storage));
            services.AddSingleton(new ConversationState(storage));

            // Create the OpenAI client
            services.AddScoped(provider => 
                new OpenAIClient(
                    new Uri(Configuration["OpenAIEndpoint"]),
                    new DefaultAzureCredential()
                )
            );

            // Create the SystemPromptCatalog
            var catalog = new List<IGptConfiguration>
            {
                new Sample()
            };
            services.AddSingleton(catalog);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();
        }
    }
}
